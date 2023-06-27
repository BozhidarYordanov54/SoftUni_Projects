using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continetsAndCountires = new Dictionary<string, Dictionary<string, List<string>>>();
            int numOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfInputs; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ");
                string continent = cmdArgs[0];
                string country = cmdArgs[1];
                string city = cmdArgs[2];

                if (!continetsAndCountires.ContainsKey(continent))
                {
                    continetsAndCountires.Add(continent, new Dictionary<string, List<string>>());
                }
                
                if (!continetsAndCountires[continent].ContainsKey(country))
                {
                    continetsAndCountires[continent].Add(country, new List<string>());
                }
                continetsAndCountires[continent][country].Add(city);
            }


            foreach (var continent in continetsAndCountires)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continetsAndCountires[continent.Key])
                {
                    Console.Write($"    {country.Key} -> ");
                    Console.Write(string.Join(", ", country.Value));
                    Console.WriteLine();
                }
            }
        }
    }
}
