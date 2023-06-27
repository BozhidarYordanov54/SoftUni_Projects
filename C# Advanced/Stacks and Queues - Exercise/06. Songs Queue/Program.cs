using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ");

            Queue<string> songsInQueue = new Queue<string>(songs);

            while (songsInQueue.Count > 0)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ");

                string command = commands[0];

                switch (command)
                {
                    case "Play":
                        songsInQueue.Dequeue();
                        break;
                    case "Add":
                        string song = string.Join(" ", commands.Skip(1));
                        if (songsInQueue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                            continue;
                        }
                        songsInQueue.Enqueue(song);
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songsInQueue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
