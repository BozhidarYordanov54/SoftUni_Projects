using System;

namespace _04._Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bookPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int hoursNeeded = bookPages / pagesPerHour;
            int hoursPerDay = hoursNeeded / days;

            Console.WriteLine(hoursPerDay);
        }
    }
}
