using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Entities
{
    public class TblError
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Source { get; set; } = "";
        public string HelpLink { get; set; } = "";
        public string StackTrace { get; set; } = "";
        public int HResult { get; set; } = 0;
        public string Message { get; set; } = "";
        public string Address { get; set; } = "";
        public int Line { get; set; } = 0;
    }
}
