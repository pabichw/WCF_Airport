using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportServerConsole.Database.Utils
{
    class DateParser
    {
        public static DateTime parse_HHmm(string stringData) {
            return DateTime.ParseExact(stringData, "HH:mm", CultureInfo.InvariantCulture);
        }
    }
}
