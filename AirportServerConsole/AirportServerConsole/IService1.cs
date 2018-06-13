using AirportServerConsole.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AirportServerConsole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    [ServiceKnownType(typeof(Flight))]
    public interface IService1
    {
        [OperationContract]
        String GetTestWelcomeMessage(Boolean wannaBeWelcomed);

        [OperationContract]
        List<Flight> GetAllFlights();

        [OperationContract]
        List<Flight> GetFlights(string citySource, string cityDestination, DateTime startDepartureTime, DateTime endDepartureTime);

        [OperationContract]
        List<Flight> GetFlightsNoTime(string citySource, string cityDestination);
        
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "AirportServerConsole.ContractType".

}
