using QubitSystem.Models.Common.Interfaces;

namespace QubitSystem.Models.Common
{
    public abstract class Auditable : BaseEntity,IAuditable
    {
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
       
    }
}
