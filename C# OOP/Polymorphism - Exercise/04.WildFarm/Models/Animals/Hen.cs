﻿using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        { }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double WeightMultiplier
            => HenWeightMultiplier;

        public override string ProduceSound()
            => "Cluck";
    }
}
