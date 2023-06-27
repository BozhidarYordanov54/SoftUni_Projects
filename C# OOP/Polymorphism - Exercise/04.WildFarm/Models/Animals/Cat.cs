﻿using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods
        => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier
            => CatWeightMultiplier;

        public override string ProduceSound() => "Meow";

    }
}
