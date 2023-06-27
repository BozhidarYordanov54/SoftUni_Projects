namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFoods) : base(name, favouriteFoods)
        {
            Name = name;
            FavouriteFoods = favouriteFoods;
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + $"{Environment.NewLine}DJAAF";
        }
    }
}