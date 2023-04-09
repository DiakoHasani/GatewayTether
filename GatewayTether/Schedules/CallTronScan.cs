using DNTScheduler;
using GatewayTether.Apis;
using GatewayTether.Entities;
using GatewayTether.Models;
using GatewayTether.Repositories;
using GatewayTether.Services;
using GatewayTether.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Schedules
{
    public class CallTronScan : ScheduledTaskTemplate
    {
        private readonly IScheduledTaskMessage _scheduledTaskMessage;
        private readonly WalletRepository walletRepository;
        private readonly ErrorRepository errorRepository;
        private readonly TronApi tronApi;
        private readonly TransferRepository transferRepository;
        private readonly WebhookRequestRepository webhookRequestRepository;
        private readonly WebhookApi webhookApi;

        TransferTronModel transferModel;
        List<TokenTransferModel> tokenTransfers;
        List<TokenTransferModel> webhookTokens;
        List<TblWebhookRequest> webhookRequests;
        List<TblWallet> wallets;
        long transferId;
        MessageModel resultPostWebhook;

        DateTime dateTimeNow;
        public CallTronScan(IScheduledTaskMessage scheduledTaskMessage)
        {
            _scheduledTaskMessage = scheduledTaskMessage;
            walletRepository = new WalletRepository();
            errorRepository = new ErrorRepository();
            tronApi = new TronApi();
            transferRepository = new TransferRepository();
            webhookRequestRepository = new WebhookRequestRepository();
            webhookApi = new WebhookApi();
        }

        public override string Name
        {
            get { return "CallTronScan"; }
        }

        public override int Order
        {
            get { return 1; }
        }

        public override bool RunAt(DateTime utcNow)
        {
            if (IsShuttingDown || Pause)
                return false;

            dateTimeNow = utcNow.AddHours(3.5);

            return dateTimeNow.Minute % 2 == 0 && dateTimeNow.Second == 0;
            //return dateTimeNow.Second == 0;
        }

        public override async void Run()
        {
            if (IsShuttingDown || Pause)
                return;

            //در اینجا تایمر متوقف می شود
            Pause = true;

            try
            {
                await _scheduledTaskMessage.ShowMessage("get tron wallets in database");

                //در اینجا لیست کیف پول های ترون گرفته می شود
                wallets = walletRepository.GetAll().Where(a => a.Enabled && a.CoinType == Enums.CoinType.Tron).ToList();

                foreach (var wallet in wallets)
                {
                    try
                    {
                        await _scheduledTaskMessage.ShowMessage("start call api get transfers");

                        //در اینجا بر اساس آدرس کیف پول ای پی آی لیست انتقال ها فراخوانی می شود
                        transferModel = await tronApi.CallTransfer_Trc20(wallet.Address);

                        await _scheduledTaskMessage.ShowMessage(transferModel.Message);

                        //اگر ای پی آی با موفقیت فراخوانی شود شرط زیر اجرا می شود
                        if (transferModel.Result)
                        {
                            //در اینجا لیست ترنسفرها گرفته می شود
                            tokenTransfers = transferModel.Token_Transfers.Where(a => a.TokenInfo.TokenAbbr == "USDT").ToList();

                            //اگر آدرس کیف پول انتقالی داشته باشد شرط زیر اجرا می شود
                            if (tokenTransfers != null && tokenTransfers.Count > 0)
                            {
                                //در متغیر زیر تمامی انتقال های جدید ذخیره می شود و آن ها را در دیتابیس ثبت کرده و سپس مقادیر آن را برای آدرس وب هوک ارسال می کند
                                webhookTokens = new List<TokenTransferModel>();

                                //اگر در آدرس کیف پول آخرین آدرس تی ایکس آیدی ذخیره شده باشد شرط زیر اجرا می شود در غیر این صورت تی ایکس آیدی آخرین انتقالی را در کیف پول ذخیره می کند
                                if (!string.IsNullOrWhiteSpace(wallet.Last_Txid))
                                {
                                    foreach (var transfer in tokenTransfers)
                                    {
                                        //اگر تی ایکس آیدی با آخرین تی ایکس آیدی ذخیره شده در کیف پول برابر نباشد یعنی این انتقالی جدید هست و آن را در لیست زیر ذخیره می کند
                                        if (transfer.Transaction_Id != wallet.Last_Txid)
                                        {
                                            webhookTokens.Add(transfer);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    webhookTokens.Add(tokenTransfers.FirstOrDefault());
                                }

                                //اگر انتقالی جدیدی اضافه شده باشد شرط زیر اجرا می شود
                                if (webhookTokens.Count > 0)
                                {
                                    //در اینجا انتقالی های جدید به دو جدول زیر اضافه می شود
                                    //TblTransfer در این جدول تمامی جزییات انتقالی ثبت می شود
                                    //TblWebhookRequest در این جدول انتقالی ها به صورت صف برای ارسال به آدرس کال بک کیف پول ثبت می شود
                                    foreach (var webhook in webhookTokens.OrderBy(a => a.Block_TS).ToList())
                                    {
                                        //در اینجا رکورد جدید به جدول ترنسفر اضافه می شود
                                        transferId = transferRepository.Add(webhook);
                                        if (transferId > 0)
                                        {
                                            await _scheduledTaskMessage.ShowMessage($"added transfer. txid: {webhook.Transaction_Id}");

                                            //در اینجا انتقالی ها اضافه می شوند
                                            webhookRequestRepository.Add(new TblWebhookRequest
                                            {
                                                CreateDate = DateTime.Now,
                                                SendCount = 0,
                                                Sended = false,
                                                Url = wallet.WebhookAddress,
                                                WalletId = wallet.Id,
                                                TransferId = transferId
                                            });
                                            await _scheduledTaskMessage.ShowMessage($"added webhookRequest. txid: {webhook.Transaction_Id}");
                                        }
                                        else
                                        {
                                            await _scheduledTaskMessage.ShowMessage($"error in add webhookRequest. txid: {webhook.Transaction_Id}");
                                        }
                                    }

                                    //در اینجا آخرین تی اکس آیدی به جدول والت اضافه می شود
                                    wallet.Last_Txid = webhookTokens.OrderByDescending(a => a.Block_TS).ToList().FirstOrDefault().Transaction_Id;
                                    walletRepository.Update(wallet);
                                    await _scheduledTaskMessage.ShowMessage($"updated Last_Txid TblWallet. walletId:{wallet.Id} , txid:{wallet.Last_Txid}");
                                }
                            }
                            else
                            {
                                await _scheduledTaskMessage.ShowMessage($"this wallet address: {wallet.Address} does not have transfers");
                            }
                        }
                        else
                        {
                            errorRepository.AddError(transferModel.Message, MethodBase.GetCurrentMethod().DeclaringType.FullName, ReflectionHelper.GetActualAsyncMethodName());
                        }
                    }
                    catch (Exception ex)
                    {
                        await _scheduledTaskMessage.ShowMessage("error in try catch get wallets. exception message: " + ex.Message ?? "");
                        errorRepository.AddError(ex, MethodBase.GetCurrentMethod().DeclaringType.FullName, ReflectionHelper.GetActualAsyncMethodName());
                    }
                    await Task.Delay(TimeSpan.FromSeconds(10));
                }

                #region فراخوانی webhookRequests
                await _scheduledTaskMessage.ShowMessage("get webhookRequests");

                //در اینجا لیست انتقالی های دریافت شده برای ارسال به آدرس کال بک گرفته می شود
                webhookRequests = webhookRequestRepository.GetWaitingForSend().OrderBy(a => a.Id).ToList();
                foreach (var webhookRequest in webhookRequests)
                {
                    try
                    {
                        resultPostWebhook = await webhookApi.PostWebhook(webhookRequest.Url, transferRepository.GetById(webhookRequest.TransferId));
                        await _scheduledTaskMessage.ShowMessage(resultPostWebhook.Message);

                        //در اینجا وب هوک ارسال می شود و اگر با موفقیت ارسال شود شرط زیر اجرا می شود
                        if (resultPostWebhook.Result)
                        {
                            webhookRequest.SendCount++;
                            webhookRequest.Sended = true;
                            webhookRequestRepository.Update(webhookRequest);
                        }
                        else
                        {
                            errorRepository.AddError(resultPostWebhook.Message, MethodBase.GetCurrentMethod().DeclaringType.FullName, ReflectionHelper.GetActualAsyncMethodName());
                            webhookRequest.SendCount++;
                            webhookRequest.Sended = false;
                            webhookRequestRepository.Update(webhookRequest);
                        }
                    }
                    catch (Exception ex)
                    {
                        await _scheduledTaskMessage.ShowMessage("error in post webhook request. exception: " + ex.Message ?? "");
                        errorRepository.AddError(ex, MethodBase.GetCurrentMethod().DeclaringType.FullName, ReflectionHelper.GetActualAsyncMethodName());
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                await _scheduledTaskMessage.ShowMessage("error in first try catch exception message:" + ex.Message ?? "");
                errorRepository.AddError(ex, MethodBase.GetCurrentMethod().DeclaringType.FullName, ReflectionHelper.GetActualAsyncMethodName());
            }
            finally
            {
                await _scheduledTaskMessage.ShowMessage("---------------------------------------------------------");
                Pause = false;
            }
        }
    }
}
