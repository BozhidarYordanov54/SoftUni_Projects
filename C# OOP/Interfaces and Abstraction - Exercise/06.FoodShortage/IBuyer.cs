namespace FoodShortage
{
    public interface IBuyer : INameAge
    {
        int Food { get; }
        void BuyFood();
    }
}
