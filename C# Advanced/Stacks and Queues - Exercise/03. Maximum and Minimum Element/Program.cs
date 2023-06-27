using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                string query = command[0];

                if (query == "1")
                {
                    int elementToPush = int.Parse(command[1]);
                    stack.Push(elementToPush);
                }
                else if (query == "2")
                {
                    stack.Pop();
                }
                else if (query == "3") 
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine(stack.Max());
                }
                else if (query == "4") 
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine(stack.Min());
                    
                }

                
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
