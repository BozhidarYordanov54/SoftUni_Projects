using System;

namespace _05.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double h = double.Parse(Console.ReadLine()) ;
            double w = double.Parse(Console.ReadLine()) ;

            //Маси на широчина
            double spaceLeftW = w - 1;
            double wTable = 0.7;
            double tablePerW = Math.Round(spaceLeftW / wTable);

            //Маси на дължина
            double tablePerH = Math.Round(h / 1.2);

            double totalPlaces = tablePerH * tablePerW - 3;

            Console.WriteLine(totalPlaces);
        }
    }
}
