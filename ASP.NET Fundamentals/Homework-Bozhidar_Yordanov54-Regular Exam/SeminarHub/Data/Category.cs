using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryConstants.NameMaxLength)]
        [Comment("Name of the category.")]
        public string Name { get; set; } = string.Empty;

        public IList<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}
