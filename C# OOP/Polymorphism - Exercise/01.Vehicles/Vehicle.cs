namespace Vehicles
{
    public abstract class Vehicle
    {
        
        public double FuelConsumption { get; private set; }
        public double FuelQuantity { get; protected set; }

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public abstract void Drive(double distance);
        public abstract void Refuel(double amount);
    }
}
