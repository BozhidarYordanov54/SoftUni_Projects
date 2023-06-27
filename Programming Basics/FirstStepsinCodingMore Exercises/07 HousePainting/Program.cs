using System;

namespace _07_HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double sideWall = x * y;
            double window = 1.5 * 1.5;
            double totalSideWalls = 2 * sideWall - 2 * window;

            double backWall = x * x;
            double door = 1.2 * 2;
            double frontAndBackWalls = 2 * backWall - door;

            double totalAreaWalls = totalSideWalls + frontAndBackWalls;

            double roofSide = 2 * (x * y);
            double triangleRoof = 2 * (x * h / 2);

            double totalAreaRoof = roofSide + triangleRoof;

            double totalGreenPaint = totalAreaWalls / 3.4;
            double totalRedPaint = totalAreaRoof / 4.3;

            Console.WriteLine($"{totalGreenPaint:f2}");
            Console.WriteLine($"{totalRedPaint:f2}");

        }
    }
}
