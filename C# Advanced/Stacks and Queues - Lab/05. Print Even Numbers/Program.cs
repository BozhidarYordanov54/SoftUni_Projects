using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberInput = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToArray();
            
            Queue<int> numbers = new Queue<int>(numberInput);

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
