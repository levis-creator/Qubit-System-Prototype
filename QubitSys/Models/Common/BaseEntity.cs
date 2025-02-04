using System.ComponentModel.DataAnnotations;

namespace QubitSys.Models.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
