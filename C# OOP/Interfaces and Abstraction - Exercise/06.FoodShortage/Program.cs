namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++) 
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                if (cmdArgs.Length == 4)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    string birthdate = cmdArgs[3];

                    IBuyer citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string camp = cmdArgs[2];

                    IBuyer rebel = new Rebel(name, age, camp);
                    buyers.Add(rebel);
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                buyers.FirstOrDefault(buyer => buyer.Name == command)?.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
