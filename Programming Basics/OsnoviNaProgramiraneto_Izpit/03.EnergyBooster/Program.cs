using System;

namespace _03.EnergyBooster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int numberOfSet = int.Parse(Console.ReadLine());

            int fruitsInPack = 0;

            if (size == "small")
            {
                fruitsInPack = 2;
            }
            else 
            {
                fruitsInPack = 5;
            }

            double priceOfSingleFruit = 0;

            if (fruit == "Watermelon")
            {
                if (size == "small")
                {
                    priceOfSingleFruit = 56;
                }
                else
                {
                    priceOfSingleFruit = 28.70;
                }
            }
            if (fruit == "Mango") 
            {
                if (size == "small")
                {
                    priceOfSingleFruit = 36.66;
                }
                else
                {
                    priceOfSingleFruit = 19.60;
                }
            }
            if (fruit == "Pineapple")
            {
                if (size == "small")
                {
                    priceOfSingleFruit = 42.10;
                }
                else 
                {
                    priceOfSingleFruit = 24.80;
                }
            }
            if (fruit == "Raspberry")
            {
                if (size == "small")
                {
                    priceOfSingleFruit = 20;
                }
                else
                {
                    priceOfSingleFruit = 15.20;
                }
            }
            double totalPriceBeforeDiscount = numberOfSet * fruitsInPack * priceOfSingleFruit;

            if (totalPriceBeforeDiscount >= 400 && totalPriceBeforeDiscount <= 1000)
            {
                totalPriceBeforeDiscount -= (totalPriceBeforeDiscount * 0.15);
            }
            else if (totalPriceBeforeDiscount > 1000)
            {
                totalPriceBeforeDiscount -= (totalPriceBeforeDiscount * 0.50);
            }

            Console.WriteLine($"{totalPriceBeforeDiscount:f2} lv.");
        }
    }
}
