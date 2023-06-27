using _07.MilitaryElite.Models;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

        }
    }
    public interface IEngineer
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string name, string lastName, string partName, int hoursWorked) : base(id, name, lastName)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public string PartName { get; private set; }
        public int HoursWorked { get; private set; }
    }
}