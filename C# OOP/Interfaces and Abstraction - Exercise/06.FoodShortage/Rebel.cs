namespace FoodShortage
{
    public class Rebel : IBuyer, INameAge
    {
        private const int DefaultBuyOrder = 5;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public int Food { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }


        public void BuyFood()
        {
            Food += DefaultBuyOrder;   
        }
    }
}
