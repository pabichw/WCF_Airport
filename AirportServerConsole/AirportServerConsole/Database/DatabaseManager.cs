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
        private const string PATH_TO_CSV = "C:\\Users\\Wiktor\\Desktop\\lab_RSO\\zad3_WCF\\AirportServerConsole\\AirportServerConsole\\Database\\flights_timetable_db.csv";

        public static List<Flight> loadFromCSV(){
            Console.WriteLine("Loading from .csv file...");
            List<Flight> records = new List<Flight>();

            try
            {
                using (var reader = new StreamReader(PATH_TO_CSV))
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

        public static List<Flight> getOnlyWithStartingCity(string citySource)
        {
            List<Flight> flights = loadFromCSV();
            List<Flight> filteredFlights = new List<Flight>();

            foreach(Flight flight in flights) {
                if (flight.getCitySource().Equals(citySource)) {
                    filteredFlights.Add(flight);
                }
            }

            return filteredFlights;
        }
    }
}
