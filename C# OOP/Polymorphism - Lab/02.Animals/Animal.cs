namespace Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, string favouriteFoods)
        {
            Name = name;
            FavouriteFoods = favouriteFoods;
        }
        public string Name { get; protected set; }

        public string FavouriteFoods { get; protected set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFoods}";
        }
    }
}