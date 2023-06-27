using System;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int filmLenght = int.Parse(Console.ReadLine());
            int lunchBrake = int.Parse(Console.ReadLine());

            double timeToEat = lunchBrake * 0.125;
            double timeToRest = lunchBrake * 0.25;

            double timeNeeded = filmLenght + timeToEat + timeToRest;

            double diff = Math.Abs(lunchBrake - timeNeeded);

            if (lunchBrake - timeNeeded >= 0)
            {
                Console.WriteLine($"You have enough time to watch {filmName} and left with {Math.Ceiling(diff)} minutes free time.");
            }
            else
            { 
                Console.WriteLine($"You don't have enough time to watch {filmName}, you need {Math.Ceiling(diff)} more minutes.");
            }
        }
    }
}
