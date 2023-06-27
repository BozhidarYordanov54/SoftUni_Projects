namespace BirthdayCelebrations
{
    public class Citizen : INameBirthday, IId
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name { get; }
        public string Birthdate { get; }
        public string Id { get;}
        public int Age { get; }
    }
}