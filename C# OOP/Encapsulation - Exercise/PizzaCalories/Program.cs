using System;

namespace PizzaCalories
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] name = Console.ReadLine().Split(" ");
                string[] dough = Console.ReadLine().Split(" ");

                Pizza pizza = new Pizza(name[1], new Dough(dough[1], dough[2], double.Parse(dough[3])));

                string command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingsInput = command.Split(" ");
                    Topping topping = new Topping(toppingsInput[1], double.Parse(toppingsInput[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
