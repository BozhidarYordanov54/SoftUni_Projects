using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ');
            Queue<string> queue= new Queue<string>(names);
            int n = int.Parse(Console.ReadLine());
            int tosses = 1;

            while (queue.Count != 1)
            {
                string child = queue.Dequeue();

                if (tosses < n)
                {
                    tosses++;
                    queue.Enqueue(child);
                }
                else
                {
                    Console.WriteLine($"Removed {child}");
                    tosses = 1;
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
