using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Helpers
{
    public static class ExceptionHelper
    {
        public static int GetLineNumber(this Exception e)
        {
            var lineNumber = 0;
            try
            {
                lineNumber = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(' ')));
            }
            catch (Exception) { }
            return lineNumber;
        }
    }
}
