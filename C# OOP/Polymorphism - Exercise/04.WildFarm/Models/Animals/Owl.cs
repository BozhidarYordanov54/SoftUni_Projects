using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;

        public Owl(string name, double weight, int foodEeaten) : base(name, weight, foodEeaten)
        {

        }

        public override IReadOnlyCollection<Type> PreferredFoods
        => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier
            => OwlWeightMultiplier;

        public override string ProduceSound()
            => "Hoot Hoot";
    }
}
