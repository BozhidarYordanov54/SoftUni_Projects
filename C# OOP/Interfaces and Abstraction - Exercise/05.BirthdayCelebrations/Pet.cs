namespace BirthdayCelebrations
{
    public class Pet : INameBirthday
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; }
        public string Birthdate { get; }
    }
}