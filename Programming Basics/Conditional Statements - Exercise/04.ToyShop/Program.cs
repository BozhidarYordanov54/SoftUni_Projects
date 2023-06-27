using System;

namespace _04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceForTrip = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollCount = int.Parse(Console.ReadLine());
            int bearCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int truckCount = int.Parse(Console.ReadLine());

            double priceForPuzzles = puzzleCount * 2.60;
            double dollPrice = dollCount * 3.0;
            double bearPrice = bearCount * 4.10;
            double minionsPrice = minionsCount * 8.20; 
            double truckPrice = truckCount * 2;

            double income = priceForPuzzles + dollPrice + bearPrice + minionsPrice + truckPrice;

            int toysCount = puzzleCount + dollCount + bearCount + minionsCount + truckCount;

            double discount = 0;

            if (toysCount >= 50)
            {
                discount = income * 0.25 ;
                income = income - discount;
            }

            double rent = income * 0.1;

            double finalIncome = income - rent;

            if(finalIncome >= priceForTrip)
            {
                double moneyLeft = finalIncome - priceForTrip;
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
            else
            {
                double moneyNeeded = priceForTrip - finalIncome; 
                Console.WriteLine($"Not enough money! {moneyNeeded:f2} lv needed.");
            }
        }
    }
}
