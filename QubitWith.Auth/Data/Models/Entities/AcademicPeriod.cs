using QubitWith.Auth.Data.Models.Common;

namespace QubitWith.Auth.Data.Models.Entities
{
    public class AcademicPeriod:Auditable
    {
        public string Period { get; set; } = string.Empty;
        public string AcademicYear { get; set; } = string.Empty;
    }
}
