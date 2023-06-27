using System;

namespace _07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videocard = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            int videocardPrice = videocard * 250;
            double cpuPrice = videocardPrice * 0.35 * cpu;
            double ramPrice = videocardPrice * 0.1 * ram;

            double priceNoDiscount = videocardPrice + cpuPrice + ramPrice;

            double discount = 0;

            if (videocard > cpu)
            {
                discount = priceNoDiscount * 0.15;
            }

            double finalPrice = priceNoDiscount - discount;

            if (budget >= finalPrice)
            {
                double budgetLeft = Math.Abs(budget - finalPrice);
                Console.WriteLine($"You have {budgetLeft:f2} leva left!");
            }
            else
            {
                double budgetNeeded = Math.Abs(finalPrice - budget);
                Console.WriteLine($"Not enough money! You need {budgetNeeded:f2} leva more!");
            }
        }
    }
}
