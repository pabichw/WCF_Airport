using AirportServerConsole.Database.Utils;
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
        private List<Flight> currentQueryFlights;

        public DatabaseManager() {
            currentQueryFlights = null;
        }
        public DatabaseManager loadAll()
        {
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
                        Flight flight = new Flight(values[0], values[1], DateParser.parse_HHmm(values[2]), DateParser.parse_HHmm(values[3]));
                        records.Add(flight);
                    }
                    currentQueryFlights = records;
                    return this;
                }
            }
            catch (Exception e)
            {
                Flight flight = new Flight("fakap_while_loadAll()", e.Message, new DateTime(), new DateTime());
                currentQueryFlights.Add(flight);
                return this;
            }
        }

        public DatabaseManager getFlightsWithDepartureInTimeRange(DateTime startDepartureTime, DateTime endDepartureTime)
        {
            List<Flight> filteredFlights = new List<Flight>();

            foreach(Flight flight in currentQueryFlights){
                int isFlightDepartureLaterThanClientStartTime = DateTime.Compare(flight.getTimeDeparture(), startDepartureTime);
                int isFlightDepartureEarlierThanClientEndTime = DateTime.Compare(endDepartureTime, flight.getTimeDeparture());

                if (isFlightDepartureLaterThanClientStartTime >= 0 && isFlightDepartureEarlierThanClientEndTime >= 0)
                    filteredFlights.Add(flight);

            }
            currentQueryFlights = filteredFlights;
            return this;
        }

        public DatabaseManager getFlightsWithStartingCityOf(string citySource){
            List<Flight> filteredFlights = new List<Flight>();

            foreach(Flight flight in currentQueryFlights) 
                if (flight.getCitySource().Equals(citySource)) 
                    filteredFlights.Add(flight);    

            currentQueryFlights = filteredFlights;
            return this;
        }
        public DatabaseManager getFlightsWithDestinatioCityOf(string cityDestination) {
            List<Flight> filteredFlights = new List<Flight>();

            foreach (Flight flight in currentQueryFlights)
                if (flight.getCityTarget().Equals(cityDestination))
                    filteredFlights.Add(flight);

            currentQueryFlights = filteredFlights;
            return this;
        }

        public DatabaseManager getFlightsWithShifts(string citySource, string cityDestination, DateTime timeDeparture, DateTime timeArrival) {
            List<Flight> filteredFlights = new List<Flight>();

            foreach (Flight flight in currentQueryFlights)
                if (flight.getCityTarget().Equals(cityDestination) || flight.getCitySource().Equals(citySource))
                    filteredFlights.Add(flight);

            foreach (Flight flight in filteredFlights) {
                String potentialBufferCity = flight.getCityTarget();
                DatabaseManager db_manager = new DatabaseManager();
                List<Flight> potenialBufferConnections = db_manager.loadAll().getFlightsWithStartingCityOf(potentialBufferCity).GetFlights();

                foreach (Flight potenialBufferConnection in potenialBufferConnections) {
                    List<Flight> shift = new List<Flight>();

                    while (true) {

                        if (potenialBufferConnection.getCityTarget().Equals(cityDestination)) {
                         //   shift
                        }
                        else {
                        }
                    }
                }
            }
            return this;
        }

        public List<Flight> GetFlights() {
            return currentQueryFlights;
        }
    }
}
