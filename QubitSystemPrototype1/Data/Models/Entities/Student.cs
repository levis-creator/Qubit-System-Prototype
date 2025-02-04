using QubitSystem.Models.Common;
using QubitSystemPrototype1.Data.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QubitSystemPrototype1.Data.Models.Entities
{
    public class Student:ApplicationUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string AdmissionNo { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = [];
    }
}
