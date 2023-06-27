using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            List<int> divisors = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int[] numbers = Enumerable.Range(1, endOfRange).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var devider in divisors)
            {
                predicates.Add(p => p % devider == 0);
            }

            foreach (var number in numbers)
            {
                bool isDeviseble = true;

                foreach (var match in predicates) 
                {
                    if (!match(number))
                    {
                        isDeviseble = false;
                        break;
                    }
                }

                if (isDeviseble)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
