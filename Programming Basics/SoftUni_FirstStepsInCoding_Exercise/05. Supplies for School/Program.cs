using System;

namespace _05._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Pencils = int.Parse(Console.ReadLine());
            int Markers = int.Parse(Console.ReadLine());
            int litersDetergent = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            
            double pencilCost = Pencils * 5.80;
            double markersCost = Markers * 7.20;
            double detergentPerLiter = litersDetergent * 1.20;
            double totalPrice = pencilCost + markersCost + detergentPerLiter;
            double discountTotal = totalPrice - (totalPrice * discount / 100);

            Console.WriteLine(discountTotal);

            
        }
    }
}
