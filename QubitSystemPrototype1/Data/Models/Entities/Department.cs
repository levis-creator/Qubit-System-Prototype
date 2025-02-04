using QubitSystem.Models.Common;
using QubitSystemPrototype1.Data.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace QubitSystemPrototype1.Data.Models.Entities
{
    public class Department : Auditable
    {
        [Required(ErrorMessage = "Department Name is required.")]
        public string DepartmentName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Department Code is required.")]
        public string DepartmentCode { get; set; } = string.Empty;
        public ICollection<Course>? Courses { get; set; } = [];
    }
}
