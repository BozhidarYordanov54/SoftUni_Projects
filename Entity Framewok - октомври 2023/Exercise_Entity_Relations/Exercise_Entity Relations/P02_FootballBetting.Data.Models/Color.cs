using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        [Required]
        [MaxLength(Constants.ColorNameMaxLength)]
        public string? Name { get; set; }

        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual List<Team>? PrimaryKitTeams { get; set; }
        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual List<Team>? SecondaryKitTeams { get; set; }

    }
}
