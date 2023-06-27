namespace Animals
{
    public interface IAnimal
    {
        public string Name { get; }
        public string FavouriteFoods { get; }
        string ExplainSelf();
    }
}