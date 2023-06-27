using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class Soldier : ISoldier
    {
        public Soldier(string id, string name, string lastName)
        {
            ID = id;
            Name = name;
            LastName = lastName;
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}