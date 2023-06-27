using System;

namespace ClassMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Students student = new Students()
            {
                FirstName = "Jorko",
                LastName = "Georgiev",
                Age = 30,
            };

            student.Print();
        }
    }
}
