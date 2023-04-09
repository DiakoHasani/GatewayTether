using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Services
{
    public interface IScheduledTaskMessage
    {
        Task ShowMessage(string message);
        Task ClearMessage();
    }
}
