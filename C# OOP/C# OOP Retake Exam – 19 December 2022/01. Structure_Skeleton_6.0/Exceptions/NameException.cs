using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UniversityCompetition.Exceptions
{
    public class NameException : Exception
    {
        private const string DefaultNameException = "Name cannot be null or whitespace!";

        public NameException()
            :base(DefaultNameException)
        {
            
        }

        public NameException(string message) 
            : base(message) 
        {
            
        }
    }
}
