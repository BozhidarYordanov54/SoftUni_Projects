using System.Text.RegularExpressions;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carSpecs = Console.ReadLine().Split(" ");
            string[] TruckSpecs = Console.ReadLine().Split(" ");

            Vehicle car = new Car(double.Parse(carSpecs[1]), double.Parse(carSpecs[2]));
            Vehicle truck = new Truck(double.Parse(TruckSpecs[1]), double.Parse(TruckSpecs[2]));

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ");

                if (cmdArgs[0] == "Drive")
                {
                    double distance = double.Parse(cmdArgs[2]);
                    if (cmdArgs[1] == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (cmdArgs[1] == "Truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if (cmdArgs[0] == "Refuel")
                {
                    double refuelAmount = double.Parse(cmdArgs[2]);
                    if (cmdArgs[1] == "Car")
                    {
                        car.Refuel(refuelAmount);
                    }
                    else if (cmdArgs[1] == "Truck")
                    {
                        truck.Refuel(refuelAmount);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
