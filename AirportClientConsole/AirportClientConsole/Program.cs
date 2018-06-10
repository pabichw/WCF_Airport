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
                    getFlights(commandChain[1], commandChain[2], commandChain[3], commandChain[4]);
                    break;
                default:
                    break;
            }
        }

        private static void getFlights(string citySource, string cityDestination, string startArrivalTime, string endArrivalTime)
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
            Console.WriteLine("///////////////////////////////////////////////\n" +
                            "                    FLIGHTS                    \n" +
                            "///////////////////////////////////////////////\n" +
                            "FROM:\t\tDESTINATNION:\tDEPARTURE:\tARRIVAL:\t");
            foreach (AirportServerConsole.Database.Flight flight in flights)
            {
                Console.WriteLine(flight.citySource + "\t\t" + flight.cityTarget + "\t"
                                  + flight.timeDeparture + "\t" + flight.timeArrive);
            }
        }

        private static void displayMenu()
        {
            Console.Write("--CLIENT CONSOLE--\n/all - to get all flights\n/flight <start> <destiny> - flights on a particular road\nexit - to exit\n");
        }
    }
}
