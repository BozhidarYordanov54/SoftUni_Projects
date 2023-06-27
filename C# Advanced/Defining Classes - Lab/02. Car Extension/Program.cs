using System;

namespace _02._Car_Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManufacturer car = new CarManufacturer();
            {
                car.Make = "BMW";
                car.Model = "X5";
                car.Year = 2017;
                car.FuelQuantity = 60;
                car.FuelConsumption = 5;
            }
            car.FuelQuantity = 100;
            car.FuelQuantity = 2;

            car.Drive(10);
            car.Drive(1000);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
