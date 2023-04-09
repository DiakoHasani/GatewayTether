using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Models
{
    public class TokenTransferModel
    {
        public string Transaction_Id { get; set; }
        public long Block_TS { get; set; }
        public string From_Address { get; set; }
        public string To_Address { get; set; }
        public string Contract_Address { get; set; }
        public string Quant { get; set; }
        public bool Confirmed { get; set; }
        public string ContractRet { get; set; }
        public string FinalResult { get; set; }
        public TokenInfoModel TokenInfo { get; set; }
        public bool FromAddressIsContract { get; set; }
        public bool ToAddressIsContract { get; set; }
        public bool Revert { get; set; }
    }
}
