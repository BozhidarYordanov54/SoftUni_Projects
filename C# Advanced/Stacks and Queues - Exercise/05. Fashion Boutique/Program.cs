using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int capacityRack = int.Parse(Console.ReadLine());

            int currentRack = capacityRack;
            int numberOfRacks = 1;

            Stack<int> stack = new Stack<int>(clothes);

            while (stack.Any())
            {
                currentRack -= stack.Peek();

                if (currentRack < 0)
                {
                    currentRack = capacityRack;
                    numberOfRacks++;

                    continue;
                }

                stack.Pop();
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}
