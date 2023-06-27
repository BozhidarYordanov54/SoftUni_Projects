using System;

namespace _05.SuitcasesLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double aircraftLoadCapacity = double.Parse(Console.ReadLine());

            string inputString = Console.ReadLine();
            int counterSuitcase = 0;

            while (inputString != "End")
            {
                double currentSuitcaseVolume = double.Parse(inputString);
                counterSuitcase++;

                if (counterSuitcase % 3 == 0)
                {
                    currentSuitcaseVolume *= 1.1;
                }

                if (currentSuitcaseVolume > aircraftLoadCapacity)
                {
                    Console.WriteLine("No more space!");
                    counterSuitcase--;
                    break;
                }

                aircraftLoadCapacity = aircraftLoadCapacity - currentSuitcaseVolume;

                inputString = Console.ReadLine();
            }

            if (inputString == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {counterSuitcase} suitcases loaded.");
        }
    }
}
