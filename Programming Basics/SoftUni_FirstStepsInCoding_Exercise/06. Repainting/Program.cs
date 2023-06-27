using System;

namespace _06._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());           
            double bags = 0.40;

            double nylonPrice = (nylon + 2) * 1.50;
            double paintPrice = (paint  + 0.1) * 14.5;
            double thinnerPrice = thinner * 5;

           double materialPrice = nylonPrice + paintPrice + thinnerPrice + bags;
           double workerPrice = (materialPrice * 0.3) * time;

            Console.WriteLine(paintPrice);
           
        }
    }
}
