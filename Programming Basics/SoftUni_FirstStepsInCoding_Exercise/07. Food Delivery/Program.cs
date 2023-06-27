using System;

namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veggieMenu = int.Parse(Console.ReadLine());
            double delivery = 2.50;

            double chickenValue = chickenMenu * 10.35;
            double fishValue = fishMenu * 12.40;
            double veggieValue = veggieMenu * 8.15;

            double menuTotal = chickenValue + fishValue + veggieValue;

            double desert = menuTotal * 0.2;

            double totalRecipe = menuTotal + desert + delivery;

            Console.WriteLine(totalRecipe);
        }
    }
}
