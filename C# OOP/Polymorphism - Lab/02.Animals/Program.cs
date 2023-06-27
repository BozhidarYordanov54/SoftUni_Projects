namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>
            {
                new Cat("Peter", "Whiskas"),
                new Dog("George", "Meat")
            };

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ExplainSelf());
            }

        }
    }
}