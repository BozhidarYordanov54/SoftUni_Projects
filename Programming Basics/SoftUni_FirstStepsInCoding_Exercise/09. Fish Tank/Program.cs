using System;

namespace _09._Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            double percentFull = double.Parse(Console.ReadLine());

            double volumeAquarium = a * b * c;
            double volumeLiters = volumeAquarium * 0.001;

            double percent = percentFull / 100;
            
            Console.WriteLine(volumeLiters * (1 - percent));
            
        }
    }
}
