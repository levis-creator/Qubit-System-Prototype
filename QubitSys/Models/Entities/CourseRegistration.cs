using QubitSys.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QubitSys.Models.Entities
{
    public class CourseRegistration:Auditable
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
    }
}
