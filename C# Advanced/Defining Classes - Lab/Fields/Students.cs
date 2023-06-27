using System;
using System.Collections.Generic;
using System.Text;

namespace Fields
{
    internal class Students
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public void PrintStudent()
        {
            Console.WriteLine(firstName);
        }
    }
}
