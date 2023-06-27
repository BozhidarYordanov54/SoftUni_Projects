using System.Xml.Linq;

namespace Raiding
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = CreateHero(name, type);
                if (hero != null)
                {
                    heroes.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid Hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            
            int totalHeroPower = heroes.Sum(h => h.Power);
            bool isBeaten = false;
            foreach (BaseHero h in heroes) 
            {
                Console.WriteLine(h.CastAbility());
                bossPower -= h.Power;
                if (bossPower <= 0)
                {
                    isBeaten = true;
                }
            }

            if (isBeaten)
            {
                Console.WriteLine("Victory!");
            }
            else 
                Console.WriteLine("Defeat...");

        }
        static BaseHero CreateHero(string name, string type)
        {
            switch (type)
            {
                case nameof(Druid):
                    return new Druid(name);
                case nameof(Paladin):
                    return new Paladin(name);
                case nameof(Rogue):
                    return new Rogue(name);
                case nameof(Warrior):
                    return new Warrior(name);
                default:
                    return null;
            }
        }
    }
}