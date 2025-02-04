using QubitSys.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QubitSys.Models.Entities
{
    public class Course : Auditable
    {
        
        [Required]
        public string CourseName { get; set; } = string.Empty;
        [Required]
        public string CourseCode { get; set; } = string.Empty;
        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Student>? Students { get; set; }
    }
}
