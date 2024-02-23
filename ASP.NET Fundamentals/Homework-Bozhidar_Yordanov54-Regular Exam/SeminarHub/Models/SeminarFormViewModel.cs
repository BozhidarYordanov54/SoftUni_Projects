using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants.ErrorMessages;
using static SeminarHub.Data.DataConstants.SeminarConstants;

namespace SeminarHub.Models
{
    public class SeminarFormViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(TopicMaxLength, MinimumLength = TopicMinLength, ErrorMessage = LengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(LecturerMaxLength, MinimumLength = LecturerMinLength, ErrorMessage = LengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(DetailsMaxLength, MinimumLength = DetailsMinLength, ErrorMessage = LengthErrorMessage)]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public string DateAndTime { get; set; } = string.Empty;

        [Required]
        [Range(DurationMin, DurationMax, ErrorMessage = DurationErrorMessage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public int CategoryId { get; set; }

        public string OrganizerId { get; set; } = string.Empty;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
