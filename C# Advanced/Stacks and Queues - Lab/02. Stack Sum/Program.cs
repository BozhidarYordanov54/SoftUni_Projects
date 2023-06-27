using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberInput = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numberInput);

            string[] command = Console.ReadLine()
                .Split();

            while (command[0].ToLower() != "end")
            {
                string initialCmd = command[0].ToLower();

                if (initialCmd == "add")
                {
                    int num1 = int.Parse(command[1]);
                    int num2 = int.Parse(command[2]);

                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if(initialCmd == "remove")
                {
                    int numsToRemove = int.Parse(command[1]);

                    if (numsToRemove > stack.Count)
                    {
                        command = Console.ReadLine()
                        .Split();
                        continue;
                    }

                    for (int i = 0; i < numsToRemove; i++)
                    {
                        stack.Pop();
                    }
                }

                command = Console.ReadLine()
                    .Split();
            }

            int sum = 0;

            foreach (int number in stack)
            {
                sum += number;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
