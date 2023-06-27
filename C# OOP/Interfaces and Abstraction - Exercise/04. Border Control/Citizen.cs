namespace BorderControl
{
    public class Citizen : IId , ICitizen
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age =  age;
            Id = id;
        }
        public string Id { get; }

        public string Name { get; }

        public int Age { get; }
    }
}