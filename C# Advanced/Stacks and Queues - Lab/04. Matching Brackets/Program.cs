using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i);
                }
                if (input[i] == ')')
                {
                    int openBracket = brackets.Pop();

                    for (int j = openBracket; j <= i; j++)
                    {
                        Console.Write($"{input[j]}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
