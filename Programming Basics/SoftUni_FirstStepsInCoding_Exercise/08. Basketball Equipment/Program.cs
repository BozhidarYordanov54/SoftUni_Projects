using System;

namespace _08._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearlyTax = int.Parse(Console.ReadLine());
            double shoesPercent =  yearlyTax * 40 / 100;
            double shoes = yearlyTax - shoesPercent;

            double basketballClothesPercent = shoes * 20 / 100;
            double basketballClothes = shoes - basketballClothesPercent;

            double basketballBall = basketballClothes * 1 / 4;

            double basketballAccessories = basketballBall * 1 / 5;

            double allTaxes = yearlyTax + shoes + basketballClothes + basketballBall + basketballAccessories;

            Console.WriteLine(allTaxes);

        }
    }
}
