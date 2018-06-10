using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClientConsole.Utils
{
    class CommandParser
    {
        private static string[] AVAILABLE_COMMANDS = { "all", "flight", "exit" };

        internal static string[] parse(string userInput)
        {
            if (char.Equals(userInput[0], "/"))
                return null;

            string[] commandChain = userInput.Replace("/", string.Empty).Split(' ');

            if (Array.IndexOf(AVAILABLE_COMMANDS, commandChain[0]) < 0)
                return null;

            return commandChain;
        }

        internal static bool isProperCommand(object p)
        {
            throw new NotImplementedException();
        }
    }
}
