using System;

namespace _05.GodzillaVs.Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double filmBudget = double.Parse(Console.ReadLine());
            int numberOfPeople = int.Parse(Console.ReadLine());
            double priceForClothing = double.Parse(Console.ReadLine());

            double decor = filmBudget * 0.1;
            double clothingPrice = numberOfPeople * priceForClothing;
            double totalPrice = clothingPrice + decor;

            double discount = 0;

            if (numberOfPeople >= 150)
            {
                discount = clothingPrice * 0.1;
            }


            if (filmBudget < totalPrice)
            {
                double moneyNedeed = filmBudget - totalPrice + discount;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(moneyNedeed):f2} leva more.");
                
            }
            else 
            {
                double moneyLeft = filmBudget - totalPrice + discount;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
                
            }
        }
    }
}
