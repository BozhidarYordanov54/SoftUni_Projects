using System;

namespace _06.Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceSkumriq = double.Parse(Console.ReadLine());
            double priceCaca = double.Parse(Console.ReadLine());
            double kgPalamud = double.Parse(Console.ReadLine());
            double kgSafrid = double.Parse(Console.ReadLine());
            double kgMidi = double.Parse(Console.ReadLine());

            double palamudPrice = priceSkumriq + priceSkumriq * 0.6;
            double sumPalamud = kgPalamud * palamudPrice;

            double safridPrice = priceCaca + priceCaca * 0.8;
            double safridSum = kgSafrid * safridPrice;

            double sumMidi = kgMidi * 7.5;

            double totalPrice = sumPalamud + safridSum + sumMidi;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
