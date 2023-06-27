using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printing = x => Console.WriteLine($"Sir {x}");

            string[] names = Console.ReadLine().Split(' ');

            names.ToList().ForEach(printing);
        }
    }
}
