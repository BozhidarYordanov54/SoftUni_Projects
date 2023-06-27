using System.Reflection;
using System.Runtime.CompilerServices;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double tankCapacity;
        private double fuelConsumption;
        public double fuelQuantity;
        
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                if (value <= 0 || value > TankCapacity) 
                {
                    Console.WriteLine($"Cannot fit {value} fuel in the tank");
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double TankCapacity
        {
            get { return tankCapacity; }
            private set { tankCapacity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value; }
        }
        public void Drive(double distance)
        {
            double fuelNeeded = distance * (FuelConsumption + AirConditionerFuelConsumption());
            if(FuelQuantity >= fuelNeeded)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }
        public virtual void DriveEmpty(double distance)
        {
            //Method for bus without passengers
        }
        
        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + amount > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                FuelQuantity += amount;
            }
        }

        protected virtual double AirConditionerFuelConsumption()
        {
            return 0;
        }

        protected bool NeedFuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return false;
            }

            if (amount + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                return false;
            }
            return true;
        }
    }
}
