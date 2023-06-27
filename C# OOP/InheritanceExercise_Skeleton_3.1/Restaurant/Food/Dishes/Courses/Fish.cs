namespace Restaurant
{
    public class Fish : MainDish
    {
        public const double FishGrams = 22;

        public Fish(string name, decimal price, double grams) : base(name, price, FishGrams)
        {

        }
    }
}
