using System;

namespace _03._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositSumm = double.Parse(Console.ReadLine());
            double depositTime = double.Parse(Console.ReadLine());
            double yearPercent = double.Parse(Console.ReadLine());

            Console.WriteLine(depositSumm + depositTime * ((depositSumm * yearPercent / 100) / 12));
        }
    }
}
