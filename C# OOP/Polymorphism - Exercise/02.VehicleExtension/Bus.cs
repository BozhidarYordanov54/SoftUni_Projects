namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AirConConsumptionWithPeople = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override void DriveEmpty(double distance)
        {
            double requiredFuel = FuelConsumption * distance;

            if (requiredFuel <= FuelQuantity)
            {
                FuelQuantity -= requiredFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        protected override double AirConditionerFuelConsumption()
        {
            return AirConConsumptionWithPeople;
        }
    }
}
