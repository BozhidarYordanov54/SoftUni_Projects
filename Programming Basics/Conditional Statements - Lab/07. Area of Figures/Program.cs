using System;

namespace _07._Area_of_Figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if(figure == "square")
            {
                double a = Console.ReadLine();
                Console.WriteLine(a * a);
            }
        }
    }
}
