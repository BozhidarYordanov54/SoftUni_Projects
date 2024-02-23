using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data
{
    public class Seminar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SeminarConstants.TopicMaxLength)]
        [Comment("Topic of the seminar.")]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [MaxLength(SeminarConstants.LecturerMaxLength)]
        [Comment("Lecturer name of the seminar.")]
        public string Lecturer { get; set; } = string.Empty;

        [Required]
        [MaxLength(SeminarConstants.DetailsMaxLength)]
        [Comment("Details of the seminar.")]
        public string Details { get; set; } = string.Empty;

        [Required]
        [Comment("Organizer ID.")]
        public string OrganizerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OrganizerId))]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        [Comment("Date and time of the seminar.")]
        public DateTime DateAndTime { get; set; }

        [Required]
        [Range(SeminarConstants.DurationMin, SeminarConstants.DurationMax)]
        [Comment("Duration of the seminar in minutes.")]
        public int Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public IList<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }
}
