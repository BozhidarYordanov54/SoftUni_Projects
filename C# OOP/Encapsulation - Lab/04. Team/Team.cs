using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team 
    {
		public Team(string name)
		{
			Name = name;
			firstTeam = new List<Person>();
			reserveTeam = new List<Person>();
		}
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private List<Person> firstTeam;
		public IReadOnlyList<Person> FirstTeam
		{
			get { return firstTeam.AsReadOnly(); }
		}

		private List<Person> reserveTeam;
		public IReadOnlyList<Person> ReserveTeam
		{
			get { return reserveTeam.AsReadOnly(); }
		}

		public void AddPlayer(Person person) 
		{
			if (person.Age < 40)
			{
				firstTeam.Add(person);
			}
			else 
			{ 
				reserveTeam.Add(person); 
			}
		}

        public override string ToString()
        {
			return $"First team has {firstTeam.Count} players {Environment.NewLine}Reserve team has {reserveTeam.Count} players.";
        }
    }
}
