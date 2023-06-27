using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> filterByUpper = s => s[0] == char.ToUpper(s[0]) && char.IsLetter(s[0]);

            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => filterByUpper(x))
                .ToArray();

            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }
    }
}
