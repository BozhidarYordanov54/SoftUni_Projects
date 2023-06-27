using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] nameMoneyPairs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var nameMoneyPair in nameMoneyPairs)
                {
                    string[] nameMoney = nameMoneyPair.Split('=');
                    Person person = new Person(nameMoney[0], decimal.Parse(nameMoney[1]));
                    people.Add(person);
                }

                string[] productsCosts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var productPairCost in productsCosts)
                {
                    string[] productCost = productPairCost.Split("=");
                    Product productToAdd = new Product(productCost[0], decimal.Parse(productCost[1]));
                    products.Add(productToAdd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] personBuyOrder = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = personBuyOrder[0];
                string productName = personBuyOrder[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (person != null && product != null)
                {
                    Console.WriteLine(person.Add(product));
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}
