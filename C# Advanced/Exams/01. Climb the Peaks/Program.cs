using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Climb_the_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> foodPortion = new Stack<int>();

            List<int> foodPortions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            foreach (var portion in foodPortions)
            {
                foodPortion.Push(portion);
            }

            List<int> stamina = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            Dictionary<string, int> peaks = new Dictionary<string, int>();
            peaks.Add("Vihren", 80);
            peaks.Add("Kutelo", 90);
            peaks.Add("Banski Suhodol", 100);
            peaks.Add("Polezhan", 60);
            peaks.Add("Kamenitza", 70);

            for (int i = 0; i < peaks.Count; i++)
            {
                
            }
        }
    }
}
