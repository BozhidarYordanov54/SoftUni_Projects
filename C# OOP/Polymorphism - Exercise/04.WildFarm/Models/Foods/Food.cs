using _04.WildFarm.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Foods
{
    public class Food : IFood
    {
        public Food(int quality)
        {
            Quantity = quality;
        }

        public int Quantity {get; private set;}
    }
}
