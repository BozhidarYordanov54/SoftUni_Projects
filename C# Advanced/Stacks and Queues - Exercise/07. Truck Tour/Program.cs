using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int litersperKilometer = 1;

            int number = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < number; i++)
            {
                int[] pump = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(pump);
            }

            int startIndex = 0;

            while (true)
            {
                int totalLiters = 0;
                bool isComplete = true;

                foreach (var item in pumps)
                {
                    int lites = item[0];
                    int distance = item[1];

                    totalLiters += lites;

                    if (totalLiters - distance * litersperKilometer < 0)
                    {
                        startIndex++;

                        int[] currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);

                        isComplete = false;

                        break;
                    }

                    totalLiters -= distance * litersperKilometer;
                }

                if (isComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
                
            }
            
        }
    }
}
