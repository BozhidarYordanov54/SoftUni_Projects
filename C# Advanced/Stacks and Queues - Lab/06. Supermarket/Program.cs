using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customer = new Queue<string>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    while (customer.Count > 0)
                    {
                        Console.WriteLine(customer.Dequeue());
                    }
                }
                else
                {
                    customer.Enqueue(command);
                }
            }

            if (customer.Count >= 0)
            {
                Console.WriteLine($"{customer.Count} people remaining.");
            }
        }
    }
}
