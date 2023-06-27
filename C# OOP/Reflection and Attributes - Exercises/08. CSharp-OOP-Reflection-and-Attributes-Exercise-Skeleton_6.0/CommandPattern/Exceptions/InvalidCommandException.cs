using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Exceptions
{
    public class InvalidCommandException : Exception
    {
        private static string DefaultMessage = "Invalid command type!";

        public InvalidCommandException(string message)
            : base(message)
        {
            
        }

        public InvalidCommandException()
            :base(DefaultMessage)
        {
            
        }
    }
}
