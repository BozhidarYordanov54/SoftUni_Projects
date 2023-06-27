using System;

namespace CustomQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(1);

            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine(queue[i]);
            }
        }
    }
}
