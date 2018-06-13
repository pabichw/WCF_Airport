using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AirportClientConsole.Utils;
using AirportClientConsole.ServiceReference1;

namespace AirportClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool wannaExit = false;
                while (wannaExit == false) 
                {
                    Console.Clear();
                    displayMenu();

                    string[] commandChain;
                    do
                    {
                        String userInput = Console.ReadLine();
                        commandChain = CommandParser.parse(userInput);
                    } while (commandChain == null);

                    if (commandChain[0] != "exit")
                        executeCommand(commandChain);
                    else
                        wannaExit = true;

                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }

        private static void executeCommand(string[] commandChain)
        {
            switch (commandChain[0]) {
                case "all":
                    displayAllFlights();
                    break;
                case "flight":
                    if (commandChain.Length == 5)
                        getFlights(commandChain[1], commandChain[2], DateParser.parse_HHmm(commandChain[3]), DateParser.parse_HHmm(commandChain[4]));
                    else if(commandChain.Length == 3)
                        getFlightsNoTime(commandChain[1], commandChain[2]);
                    break;
                default:
                    break;
            }
        }

        private static void getFlightsNoTime(string citySource, string cityDestination)
        {
            Console.WriteLine("Getting flight...{0} {1}", citySource, cityDestination);
            Service1Client client = new Service1Client();
            AirportServerConsole.Database.Flight[] flights = client.GetFlightsNoTime(citySource, cityDestination);
            if (flights.Length == 0)
            {
                displayReasonOfNotDisplayingFilghts(citySource, cityDestination);
            }
            else
            {
                displayFlights(flights);
            }
        }

        private static void displayReasonOfNotDisplayingFilghts(string citySource, string cityDestination)
        {
            List<string> nonExistingCities = checkIfAnyOfCitiesDoesNotExist(citySource, cityDestination);
            if (nonExistingCities.Count() > 0)
            {
                Console.WriteLine("Following cities do NOT exist: ");
                foreach (string nonExistingCity in nonExistingCities)
                {
                    Console.Write(nonExistingCity + " ");
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Connection for these parameters doesn't exist");
            }
        }

        private static List<string> checkIfAnyOfCitiesDoesNotExist(string citySource, string cityDestination)
        {
            Service1Client client = new Service1Client();
            AirportServerConsole.Database.Flight[] flights = client.GetAllFlights();
            bool citySourceNotExists = true,
                cityDestinationNotExists = true;
            foreach (AirportServerConsole.Database.Flight flight in flights) {
                if (flight.citySource.Equals(citySource) || flight.cityTarget.Equals(citySource)) {
                    citySourceNotExists = false;
                }
                if (flight.citySource.Equals(cityDestination) || flight.cityTarget.Equals(cityDestination))
                {
                    cityDestinationNotExists= false;
                }
            }

            List<string> nonExistingCities = new List<string>();

            if (citySourceNotExists)
                nonExistingCities.Add(citySource);
            if (cityDestinationNotExists)
                nonExistingCities.Add(cityDestination);

            return nonExistingCities;
        }

        private static void getFlights(string citySource, string cityDestination, DateTime startArrivalTime, DateTime endArrivalTime)
        {
            Console.WriteLine("Getting flight...{0} {1} {2} {3}", citySource, cityDestination, startArrivalTime, endArrivalTime);
            Service1Client client = new Service1Client();
            AirportServerConsole.Database.Flight[] flights = client.GetFlights(citySource, cityDestination, startArrivalTime, endArrivalTime);
            displayFlights(flights);
        }
        
        private static void displayAllFlights()
        {
            try
            {
                Service1Client client = new Service1Client();
                AirportServerConsole.Database.Flight[] flights = client.GetAllFlights();
                displayFlights(flights);
                
            }
            catch (Exception e) {
                Console.WriteLine("Ooops! Seems like I couldn't connect");
                Console.WriteLine(e.Message);
            }
        }

        private static void displayFlights(AirportServerConsole.Database.Flight[] flights)
        {
            if (flights.Length > 0)
            {
                Console.WriteLine("///////////////////////////////////////////////\n" +
                                "                    FLIGHTS                    \n" +
                                "///////////////////////////////////////////////\n" +
                                "FROM:\t\tDESTINATNION:\tDEPARTURE:\tARRIVAL:\t");
                foreach (AirportServerConsole.Database.Flight flight in flights)
                {
                    Console.WriteLine(flight.citySource + "\t\t" + flight.cityTarget + "\t"
                                      + flight.timeDeparture.ToString("HH:mm") + "\t"
                                      + flight.timeArrive.ToString("HH:mm"));
                }
            }else
            {
                Console.WriteLine("NO FLIGHTS MATCHING YOUR PARAMETERS!!!");
            }
        }

        private static void displayMenu()
        {
            Console.Write("--CLIENT CONSOLE--\n/all - to get all flights\n/flight <start> <destination> [time range of departure] - flights on a particular route\n/exit - to exit\n");
        }
    }
}
