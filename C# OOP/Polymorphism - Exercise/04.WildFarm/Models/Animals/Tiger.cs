﻿using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods
         => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier
            => TigerWeightMultiplier;

        public override string ProduceSound()
            => "ROAR!!!";
    }
}
