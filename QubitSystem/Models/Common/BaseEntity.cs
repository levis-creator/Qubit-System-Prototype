using QubitSystem.Models.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace QubitSystem.Models.Common
{
    public abstract class BaseEntity:IBaseEntity
    {
        [Key]
        public string Id { get; set; } = string.Empty;
    }
}
