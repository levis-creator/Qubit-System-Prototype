using QubitWith.Auth.Data.Models.Entities;
using QubitWith.Auth.Data.Persistence.Contracts;

namespace QubitWith.Auth.Data.Persistence
{
    public class AcademicRepository : GenericRepository<AcademicPeriod>, IAcademicRepository
    {
        public AcademicRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
