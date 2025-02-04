using Microsoft.EntityFrameworkCore;
using QubitSystemPrototype1.Data.Context;
using QubitSystemPrototype1.Data.Models.Entities;
using QubitSystemPrototype1.Data.Persistence.Contracts;

namespace QubitSystemPrototype1.Data.Persistence
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
