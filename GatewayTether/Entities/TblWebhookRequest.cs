using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Entities
{
    public class TblWebhookRequest
    {
        [Key]
        public long Id { get; set; }

        public string Url { get; set; }

        public bool Sended { get; set; }

        public int SendCount { get; set; }

        public DateTime CreateDate { get; set; }

        public int WalletId { get; set; }

        public long TransferId { get; set; }

        [ForeignKey(nameof(WalletId))]
        public TblWallet TblWallet { get; set; }

        [ForeignKey(nameof(TransferId))]
        public TblTransfer TblTransfer { get; set; }
    }
}
