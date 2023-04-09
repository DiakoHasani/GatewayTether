using GatewayTether.Entities;
using GatewayTether.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Repositories
{
    public class TransferRepository
    {
        private readonly DataContext dataContext;
        private TblTransfer transfer;

        public TransferRepository()
        {
            dataContext = new DataContext();
        }

        public long Add(TokenTransferModel model)
        {
            transfer = new TblTransfer
            {
                Confirmed = model.Confirmed,
                ContractAddress = model.Contract_Address,
                ContractRet = model.ContractRet,
                CreateDate = DateTime.Now,
                FinalResult = model.FinalResult,
                FromAddress = model.From_Address,
                FromAddressIsContract = model.FromAddressIsContract,
                Quant = model.Quant,
                Revert = model.Revert,
                TimeStamp = model.Block_TS,
                ToAddress = model.To_Address,
                ToAddressIsContract = model.ToAddressIsContract,
                TokenId = model.TokenInfo.TokenId,
                TokenAbbr = model.TokenInfo.TokenAbbr,
                TokenName = model.TokenInfo.TokenName,
                TransactionId = model.Transaction_Id
            };
            dataContext.TblTransfers.Add(transfer);
            if (dataContext.SaveChanges() > 0)
                return transfer.Id;
            return 0;
        }

        public TblTransfer GetById(long id)
        {
            return dataContext.TblTransfers.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
