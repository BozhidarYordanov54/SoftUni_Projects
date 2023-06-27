using System;

namespace _07.AreaofFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double square = a * a;

                Console.WriteLine($"{square:f3}");
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                double rectangle = a * b;

                Console.WriteLine($"{rectangle:f3}");
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double radius = r * r * Math.PI;

                Console.WriteLine($"{radius:f3}");
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                double triangle = 0.5 * a * h;

                Console.WriteLine($"{triangle:f3}");
            }
        }
    }
}
