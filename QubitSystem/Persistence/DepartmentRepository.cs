using Microsoft.EntityFrameworkCore;
using QubitSystem.Data;
using QubitSystem.Models.Entities;
using QubitSystem.Persistence.Contracts;
using QubitSystem.Repositories.Interfaces;

namespace QubitSystem.Persistence
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataDbContext context) : base(context)
        {
        }
    }
}
