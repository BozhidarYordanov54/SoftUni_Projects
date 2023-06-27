using System;
using System.Linq;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ");

            Action<string> printing = x => Console.WriteLine(x);

            names.ToList().ForEach(printing);
        }
    }
}
