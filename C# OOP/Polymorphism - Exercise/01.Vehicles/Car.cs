namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConConsumption = 0.9;
        public Car(double fuelConsumption, double fuelQuantity) 
            : base(fuelConsumption, fuelQuantity)
        {
            
        }

        public override void Drive(double distance)
        {
            double requiredFuel = (FuelConsumption + AirConConsumption) * distance;

            if (requiredFuel <= FuelQuantity)
            {
                FuelQuantity -= requiredFuel;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double amount)
        {
            FuelQuantity += amount;
        }
    }
}
