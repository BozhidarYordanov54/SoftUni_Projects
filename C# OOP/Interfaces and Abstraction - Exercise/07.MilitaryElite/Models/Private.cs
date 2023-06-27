using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate, ISoldier
    {
        public Private(string id, string name, string lastName, decimal salary) : base(id, name, lastName)
        {
            ID = id;
            Name = name;
            LastName = lastName;
            Salary = salary;
        }

        public decimal Salary { get; set; }
    }
}