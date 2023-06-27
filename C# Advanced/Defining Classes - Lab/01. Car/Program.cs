using System;

namespace _01._Car
{
    internal class Start
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "BMW";
            car.Model = "X5";
            car.Year = 2017;

            Console.WriteLine(car.Make);
        }
    }
}
