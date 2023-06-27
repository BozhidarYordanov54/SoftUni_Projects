using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passesGreenlight = int.Parse(Console.ReadLine());
            string command = string.Empty;

            Queue<string> cars = new Queue<string>();
            int passsedCounter = 0;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    if (cars.Count < passesGreenlight)
                    {
                        for (int i = 0; i <= cars.Count; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passsedCounter++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < passesGreenlight; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passsedCounter++;
                        }
                    }
                    
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine($"{passsedCounter} cars passed the crossroads.");
        }
    }
}
