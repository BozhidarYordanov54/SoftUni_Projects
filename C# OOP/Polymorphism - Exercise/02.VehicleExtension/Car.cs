namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConConsumption = 0.9;
        public Car(double fuelConsumption, double fuelQuantity, double fuelTankCapacity) 
            : base(fuelConsumption, fuelQuantity, fuelTankCapacity)
        {
            
        }

        protected override double AirConditionerFuelConsumption()
        {
            return AirConConsumption;
        }
    }
}
