using System;

namespace Fields
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Students student = new Students();

            student.FirstName = "Pesho";

            student.PrintStudent();
        }
    }
}
