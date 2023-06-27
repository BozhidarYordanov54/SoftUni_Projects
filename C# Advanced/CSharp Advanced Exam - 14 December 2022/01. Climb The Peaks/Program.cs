using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Climb_The_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] foodPortionsInput = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] dailyStaminaInput = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> foodPortions = new Stack<int>(foodPortionsInput);
            List<int> dailyStamina = new List<int>(dailyStaminaInput);

            Dictionary<string, int> peaks = new Dictionary<string, int>
            {
                { "Vihren", 80 },
                { "Kutelo", 90 },
                { "Banski Suhodol", 100 },
                { "Polezhan", 60 },
                { "Kamenitza", 70 }
            };

            List<string> conqueredPeaks = new List<string>();

            for (int i = 0; i < dailyStamina.Count; i++)
            {
                int todaysPortion = foodPortions.Pop();
                int todaysStamina = dailyStamina[i];


                int staminaPortionSum = todaysPortion + todaysStamina;

                foreach (var peak in peaks)
                {
                    string currentPeak = peak.Key;
                    int peakEnergy = peak.Value;

                    if (staminaPortionSum >= peakEnergy)
                    {
                        conqueredPeaks.Add(currentPeak);
                        peaks.Remove(currentPeak);

                        break;
                    }
                    break;
                }
            }

            if (conqueredPeaks.Count == 5)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else if (conqueredPeaks.Count < 5)
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in conqueredPeaks)
                {
                    Console.WriteLine(peak);
                }
            }
        }
    }
}