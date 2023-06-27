using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numBounds = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            bool isEven = Console.ReadLine() == "even";

            List<int> range = generateRange(numBounds[0], numBounds[1]);

            List<int> result = Match(isEven, range);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> Match(bool isEven, List<int> range)
        {
            Predicate<int> match;

            if (isEven)
            {
                match = number => number % 2 == 0;
            }
            else
            {
                match = number => number % 2 != 0;
            }

            List<int> result = new List<int>();
            foreach (int number in range)
            {
                if (match(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }

        private static Func<int, int, List<int>> generateRange = (start, end) =>
        {
            List<int> range = new List<int>();

            for (int i = start; i <= end; i++)
            {
                range.Add(i);
            }
            return range;
        };
    }
}
