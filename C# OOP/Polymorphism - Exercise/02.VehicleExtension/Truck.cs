namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TankLeak = 0.05;
        private const double AirConConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double fuelTankCapacity) 
            : base(fuelQuantity, fuelConsumption, fuelTankCapacity)
        {
        }
        protected override double AirConditionerFuelConsumption()
        {
            return AirConConsumption;
        }
        public override void Refuel(double amount)
        {
            if (NeedFuel(amount))
            {
                FuelQuantity += amount * (1 - TankLeak);
            }
        }
    }
}
