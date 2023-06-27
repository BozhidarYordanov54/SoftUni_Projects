using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < lines; i++) 
            {
                string[] cmdArgs = Console.ReadLine().Split();
                Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));

                people.Add(person);
            }

            people.OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
