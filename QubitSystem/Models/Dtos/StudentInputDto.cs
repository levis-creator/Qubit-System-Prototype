using System.ComponentModel.DataAnnotations;

namespace QubitSystem.Models.Dtos
{
    public class StudentInputDto : BaseDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string AdmissionNo { get; set; } = string.Empty;
        public string? CoursesId { get; set; }
    }
}
