using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args) {
            ServiceHost host = new ServiceHost(typeof(AirportServerConsole.Service1));
            try
            {
                host.Open();
                Console.WriteLine("Service Hosted Sucessfully\nPress anything to terminate service...");
            }
            catch (Exception e) {
                Console.Write(e.Message);
            }
            Console.Read();
        }
    }
}
