using AirportServerConsole.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AirportServerConsole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private const string PATH_TO_CSV = "..\\..\\Database\\flights_timetable_db.csv"; 
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public String GetTestWelcomeMessage(Boolean wannaBeWelcomed)
        {
            if (wannaBeWelcomed)
            {
                return "Hello stranger!";
            }
            return null;
        }

        public List<Flight> GetAllFlights() {
            
            return DatabaseManager.loadFromCSV(PATH_TO_CSV);

        }
    }
}
