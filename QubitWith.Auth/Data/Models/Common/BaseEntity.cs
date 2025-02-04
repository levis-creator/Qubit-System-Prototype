using QubitWith.Auth.Data.Models.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace QubitWith.Auth.Data.Models.Common
{
    public abstract class BaseEntity:IBaseEntity
    {
        [Key]
        public int Id { get; set; } 
    }
}
