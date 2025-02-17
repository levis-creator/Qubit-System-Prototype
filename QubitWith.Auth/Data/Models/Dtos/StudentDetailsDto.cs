using System.ComponentModel.DataAnnotations;

namespace QubitWith.Auth.Data.Models.Dtos
{
    public class StudentDetailsDto : BaseDto
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
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string AdmissionNo { get; set; } = string.Empty;

        public List<CourseDisplayDto> Courses { get; set; } = [];
        public DateOnly AdmissionDate { get; set; }

    }
}
  