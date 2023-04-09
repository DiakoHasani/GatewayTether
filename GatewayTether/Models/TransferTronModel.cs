using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Models
{
    public class TransferTronModel
    {
        public List<TokenTransferModel> Token_Transfers { get; set; }
        public bool Result { get; set; } = false;
        public string Message { get; set; }=string.Empty;
    }
}
