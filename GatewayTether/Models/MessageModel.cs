using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Models
{
    public class MessageModel
    {
        public int Code { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}
