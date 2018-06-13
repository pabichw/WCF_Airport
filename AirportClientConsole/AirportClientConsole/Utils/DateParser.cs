using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClientConsole.Utils
{
    class DateParser
    {
        public static DateTime parse_HHmm(string stringData)
        {
            try
            {
                return DateTime.ParseExact(stringData, "HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception e) {
                Console.WriteLine("Woops! Parsing date failed. Try putting date in hh:MM format!");
                return new DateTime();
            }
        }
    }
}
