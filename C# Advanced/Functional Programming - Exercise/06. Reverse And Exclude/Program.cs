using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int devider = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> reverse = numbers =>
            {
                List<int> reversed = new List<int>();
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    reversed.Add(numbers[i]);
                }

                return reversed;
            };

            Func<List<int>, Predicate<int>, List<int>> exluding = (numbers, match) =>
            {
                List<int> result = new List<int>();

                foreach (var number in numbers)
                {
                    if (!match(number))
                    {
                        result.Add(number);
                    }
                }

                return result;
            };

            numbers = exluding(numbers, n => n % devider == 0);
            numbers = reverse(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
