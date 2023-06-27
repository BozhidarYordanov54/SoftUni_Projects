
namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthday;

        }
        public string Name { get ; set ; }
        public int Age { get; set; }
        public string Id { get; set ; }
        public string Birthdate { get ; set ; }
    }
}
