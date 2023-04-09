using GatewayTether.Entities;
using GatewayTether.Models;
using System;
using System.Threading.Tasks;

namespace GatewayTether.Apis
{
    public class WebhookApi : BaseApi
    {
        public async Task<MessageModel> PostWebhook(string url, TblTransfer model)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(new TokenTransferModel
                {
                    Block_TS = model.TimeStamp,
                    Confirmed = model.Confirmed,
                    ContractRet = model.ContractRet,
                    Contract_Address = model.ContractAddress,
                    FinalResult = model.FinalResult,
                    FromAddressIsContract = model.FromAddressIsContract,
                    From_Address = model.FromAddress,
                    Quant = model.Quant,
                    Revert = model.Revert,
                    ToAddressIsContract = model.ToAddressIsContract,
                    To_Address = model.ToAddress,
                    Transaction_Id = model.TransactionId,
                    TokenInfo = new TokenInfoModel
                    {
                        TokenAbbr = model.TokenAbbr,
                        TokenId = model.TokenId,
                        TokenName = model.TokenName,
                    }
                });
                var response = await Post(url, json);
                if (response.IsSuccessStatusCode)
                {
                    var result = (await response.Content.ReadAsStringAsync()).Replace("\"", "");
                    if (result == "ok")
                    {
                        return new MessageModel
                        {
                            Result = true,
                            Message = "success call api PostWebhook"
                        };
                    }
                    else
                    {
                        return new MessageModel
                        {
                            Result = false,
                            Message = "response message PostWebhook message: " + result
                        };
                    }
                }
                else
                {
                    return new MessageModel
                    {
                        Result = false,
                        Message = "error in call PostWebhook api error message: " + await response.Content.ReadAsStringAsync()
                    };
                }
            }
            catch (Exception ex)
            {
                return new MessageModel
                {
                    Result = false,
                    Message = "error in call PostWebhook api exception message: " + ex.Message
                };
            }
        }
    }
}
