using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.XmlDocument
{
    public class LogModel<T> : BaseXmlDocumentBody where T : class
    {
        public T Data { get; set; }
    }
}
