namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFoods) : base(name, favouriteFoods)
        {
            Name = name;
            FavouriteFoods = favouriteFoods;
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + $"{Environment.NewLine}MEEOW";
        }
    }
}