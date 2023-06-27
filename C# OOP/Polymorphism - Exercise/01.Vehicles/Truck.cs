namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TankLeak = 0.05;
        private const double AirConConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void Drive(double distance)
        {
            double requiredFuel = (FuelConsumption + AirConConsumption) * distance;
            if (requiredFuel <= FuelQuantity)
            {
                FuelQuantity -= requiredFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double amount)
        {
            FuelQuantity += amount * (1 - TankLeak);
        }
    }
}
