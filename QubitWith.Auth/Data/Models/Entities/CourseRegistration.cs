using QubitWith.Auth.Data.Models.Common;
using QubitWith.Auth.Data.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QubitWith.Auth.Data.Models.Entities
{
    public class CourseRegistration:Auditable
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; } 
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
    }
}
