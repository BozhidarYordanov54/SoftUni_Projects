using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //First number - stack.Push()
            //Second number - stack.Pop()
            //Third number to look for in stack

            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] userNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(userNumbers);

            int popNums = input[1];
            int searchElement = input[2];

            for (int i = 0; i < popNums; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(searchElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count > 0)
                {
                    Console.WriteLine(numbers.Min());
                }
                else
                {
                    Console.WriteLine(numbers.Count);
                }
            }
        }
    }
}
