using System;

namespace OsnoviNaProgramiraneto_Izpit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = int.Parse(Console.ReadLine());
            double chinaUAN = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double BTC = bitcoin * 1168;
            double UANToUSD = chinaUAN * 0.15;

            double usdToLev = UANToUSD * 1.76;

            double allInLev = BTC + usdToLev;
            double levToEuro = allInLev / 1.95;

            double total = levToEuro - (levToEuro * (commision / 100));

            Console.WriteLine($"{total:f2}");
        }
    }
}
