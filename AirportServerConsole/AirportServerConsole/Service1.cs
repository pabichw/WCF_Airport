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
            return DatabaseManager.loadFromCSV();
        }

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public List<Flight> GetFlights(string citySource, string cityDestination, string startDepartureTime, string endDepartureTime)
        {
            return DatabaseManager.getOnlyWithStartingCity(citySource);
        }

        public string GetTestWelcomeMessage(bool wannaBeWelcomed)
        {
            return "Hi stranger";
        }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "AirportServerConsole.ContractType".

}
