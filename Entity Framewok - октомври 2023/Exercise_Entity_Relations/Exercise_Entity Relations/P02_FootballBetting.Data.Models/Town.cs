﻿using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        public int TownId { get; set; }
        public string? Name { get; set; }

        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country? Countries { get; set; }

        public virtual List<Player>? Players { get; set; }
        public virtual List<Town>? Towns { get; set; }
    }
}