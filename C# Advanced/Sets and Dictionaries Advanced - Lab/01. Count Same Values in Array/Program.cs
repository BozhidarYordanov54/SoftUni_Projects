using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Dictionary<double, int> sameValues = new Dictionary<double, int>();

            foreach (var number in input) 
            {
                if (!sameValues.ContainsKey(number))
                {
                    sameValues.Add(number, 0);
                }
                sameValues[number]++;
            }

            foreach (var item in sameValues)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
