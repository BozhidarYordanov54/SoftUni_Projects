using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numberPlates = new List<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(", ");
                string direction = cmdArgs[0];
                string numberPlate = cmdArgs[1];

                if (direction == "IN")
                {
                    if (!numberPlates.Contains(numberPlate))
                    {
                        numberPlates.Add(numberPlate);
                    }
                }
                else if (direction == "OUT")
                {
                    if (numberPlates.Contains(numberPlate))
                    {
                        numberPlates.Remove(numberPlate);
                    }
                }
            }

            if (numberPlates.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var plate in numberPlates)
            {
                Console.WriteLine(plate);
            }
        }
    }
}
