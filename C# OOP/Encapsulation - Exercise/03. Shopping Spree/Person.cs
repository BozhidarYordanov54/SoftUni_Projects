using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }
        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public string Add(Product product)
        {
            if (money < product.Cost)
            {
                return $"{Name} can't afford {product}";
            }
            products.Add(product);
            Money -= product.Cost;

            return $"{Name} bought {product}";
        }

        public override string ToString()
        {
            string productsString = products.Any() ? string.Join(", ", products) : "Nothing bought";

            return $"{Name} - {productsString}";
        }
    }
}
