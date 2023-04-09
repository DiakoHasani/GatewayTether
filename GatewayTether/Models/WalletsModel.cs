using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Models
{
    public class WalletsModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string CoinType { get; set; }
        public string TokenType { get; set; }
        public string Enabled { get; set; }
        public string CreateDate { get; set; }
    }
}
