using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(135, 100);
            Motorcycle motorcycle = new Motorcycle(25, 100);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(25, 100);
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(25, 100);

            motorcycle.Drive(10);
            Console.WriteLine(motorcycle.Fuel);
        }
    }
}
