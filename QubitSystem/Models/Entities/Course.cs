using QubitSystem.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QubitSystem.Models.Entities
{
    public class Course : Auditable
    {
        
        [Required]
        public string CourseName { get; set; } = string.Empty;
        [Required]
        public string CourseCode { get; set; } = string.Empty;
        [ForeignKey(nameof(Department))]
        public string? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Student>? Students { get; set; }
    }
}
