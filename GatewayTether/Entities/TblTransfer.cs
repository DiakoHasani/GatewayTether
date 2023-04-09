using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Entities
{
    public class TblTransfer
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string TransactionId { get; set; } = "";
        public long TimeStamp { get; set; } = 0;
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string ContractAddress { get; set; } = "";
        public string Quant { get; set; } = "";
        public bool Confirmed { get; set; } = false;
        public string ContractRet { get; set; } = "";
        public string FinalResult { get; set; } = "";
        public string TokenId { get; set; } = "";
        public string TokenAbbr { get; set; } = "";
        public string TokenName { get; set; } = "";
        public bool FromAddressIsContract { get; set; } = false;
        public bool ToAddressIsContract { get; set; } = false;
        public bool Revert { get; set; } = false;

        public virtual ICollection<TblWebhookRequest> TblWebhookRequests { get; set; }
    }
}
