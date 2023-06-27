using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ")
                .ToList();

            Func<List<string>, Predicate<string>, List<string>> validNames = (names, nameLenght) =>
            {
                List<string> result = new List<string>();

                foreach (var name in names)
                {
                    if (nameLenght(name))
                    {
                        result.Add(name);
                    }
                }
                return result;
            };

            names = validNames(names, x => x.Length <= nameLenght);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
