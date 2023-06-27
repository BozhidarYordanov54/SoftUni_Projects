using System;

namespace _02.MountainRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double meterPerTime = double.Parse(Console.ReadLine());

            double runTime = distanceInMeters * meterPerTime;

            double addedTime = Math.Floor(distanceInMeters / 50) * 30;

            double totalTime = runTime + addedTime;

            if (record > totalTime)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
            else 
            {
                double neededTime = Math.Abs(record - totalTime);
                Console.WriteLine($"No! He was {neededTime:f2} seconds slower.");
            }
        }
    }
}
