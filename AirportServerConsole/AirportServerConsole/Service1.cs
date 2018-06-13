using AirportServerConsole.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AirportServerConsole
{
    public class Service1 : IService1
    {
        public List<Flight> GetAllFlights()
        {
            DatabaseManager db_manager = new DatabaseManager();
            return db_manager.loadAll().GetFlights();
        }
      

        public List<Flight> GetFlights(string citySource, string cityDestination, DateTime startDepartureTime, DateTime endDepartureTime)
        {
            DatabaseManager db_manager = new DatabaseManager();
            return db_manager.loadAll().getFlightsWithStartingCityOf(citySource)
                                        .getFlightsWithDestinatioCityOf(cityDestination)
                                        .getFlightsWithDepartureInTimeRange(startDepartureTime, endDepartureTime)
                                        .GetFlights();
        }

        public List<Flight> GetFlightsNoTime(string citySource, string cityDestination) {
            DatabaseManager db_manager = new DatabaseManager();
            return db_manager.loadAll().getFlightsWithStartingCityOf(citySource)
                                        .getFlightsWithDestinatioCityOf(cityDestination)
                                        .GetFlights();
        }
        public string GetTestWelcomeMessage(bool wannaBeWelcomed)
        {
            return "Hi stranger";
        }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "AirportServerConsole.ContractType".

}
