using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(elements);

            int numberToDequeue = input[1];
            int searchedElement = input[2];

            for (int i = 0; i < numberToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(queue.Count);
                }
            }
        }
    }
}
