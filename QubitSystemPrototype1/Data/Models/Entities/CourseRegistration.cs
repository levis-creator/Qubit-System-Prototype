using QubitSystem.Models.Common;
using QubitSystemPrototype1.Data.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QubitSystemPrototype1.Data.Models.Entities
{
    public class CourseRegistration:Auditable
    {
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey(nameof(Course))]
        public string CourseId { get; set; } = string.Empty;
    }
}
