using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            Stack<string> stack = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            int sum = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                char token = char.Parse(stack.Pop());
                int num = int.Parse(stack.Pop());
            
                if (token == '+')
                {
                    sum += num;
                }
                else if (token == '-')
                {
                    sum -= num;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
