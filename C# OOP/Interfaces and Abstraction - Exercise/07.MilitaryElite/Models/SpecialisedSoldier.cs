using _07.MilitaryElite.Enums;
using System.Security.Cryptography.X509Certificates;

namespace _07.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private
    {
        public SpecialisedSoldier(string id, string name, string lastName, decimal salary, Corps corps) : base(id, name, lastName, salary)
        {
            Corps = corps;

        }
        public Corps Corps { get; private set; }
    }
}