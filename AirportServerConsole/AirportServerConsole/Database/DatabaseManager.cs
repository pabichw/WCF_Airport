using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportServerConsole.Database
{
    public class DatabaseManager
    {
        public static List<Flight> loadFromCSV(string FILE_PATH){
            Console.WriteLine("Loading from .csv file...");
            List<Flight> records = new List<Flight>();

            try
            {

                using (var reader = new StreamReader(FILE_PATH))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        Flight flight = new Flight(values[0], values[1], values[2], values[3]);
                        records.Add(flight);
                    }
                    return records;
                }
            }
            catch (Exception e) {
                Flight flight = new Flight("fakap", e.Message, null, null);
                return records;
            }
        }

    }
}
