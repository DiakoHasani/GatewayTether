using GatewayTether.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Entities
{
    public class TblWallet
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(length: 300)]
        public string Address { get; set; }

        /// <summary>
        /// در اینجا کوین ست می شود مثل ترون یا اتریوم
        /// </summary>
        public CoinType CoinType { get; set; }

        /// <summary>
        /// در اینجا توکن ست می شود مثل تتر اگر مقدار زیر نال باشد یعنی نوع آدرس ، ارز خود کوین می باشد مثل تی آر ایکس
        /// </summary>
        public TokenType? TokenType { get; set; }

        public string Last_Txid { get; set; } = string.Empty;

        public bool Enabled { get; set; }

        public DateTime CreateDate { get; set; }

        public string WebhookAddress { get; set; }

        public virtual ICollection<TblWebhookRequest> TblWebhookRequests { get; set; }
    }
}
