using System;

namespace _06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double meterPerSeconds = double.Parse(Console.ReadLine());

            double secondsNedeed = meters * meterPerSeconds;
            double resistance = Math.Floor(meters / 15);
            double addedTime = resistance * 12.5;


            double totalTime = secondsNedeed + addedTime;

            if (totalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
                
            }
            else 
            {
                double timeNeeded = Math.Abs(record - totalTime);
                Console.WriteLine($"No, he failed! He was {timeNeeded:f2} seconds slower.");
            }
        }
    }
}
