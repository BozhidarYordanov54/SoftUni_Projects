using System;

namespace _04.VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double kgVegtables = double.Parse(Console.ReadLine());
            double kgFruits = double.Parse(Console.ReadLine());
            double totalVegtableKG = double.Parse(Console.ReadLine());
            double totalFruitKG = double.Parse(Console.ReadLine());

            double vegtableProfit = totalVegtableKG * kgVegtables;
            double fruitProfit = totalFruitKG * kgFruits;

            double profit = vegtableProfit + fruitProfit;
            double profitEuro = profit / 1.94;

            Console.WriteLine($"{profitEuro:f2}");

        }
    }
}
