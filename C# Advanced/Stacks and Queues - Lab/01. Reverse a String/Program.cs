using System;
using System.Collections.Generic;

namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedString = new Stack<char>();

            foreach (var ch in input)
            {
                reversedString.Push(ch);
            }

            while (reversedString.Count > 0)
            {
                Console.Write(reversedString.Pop());
            }
        }
    }
}
