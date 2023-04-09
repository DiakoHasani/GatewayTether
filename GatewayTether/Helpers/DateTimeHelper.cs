using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GatewayTether.Helpers
{
    public static class DateTimeHelper
    {
        public static string ToShamsiDate(this DateTime dt)
        {
            var pc = new PersianCalendar();
            return $"{pc.GetYear(dt)}/{pc.GetMonth(dt)}/{pc.GetDayOfMonth(dt)}";
        }
    }
}
