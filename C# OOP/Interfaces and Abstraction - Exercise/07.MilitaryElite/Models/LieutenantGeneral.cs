using _07.MilitaryElite.Models.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string name, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates) : base(id, name, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }
    }
}