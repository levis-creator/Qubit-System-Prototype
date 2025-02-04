using Microsoft.EntityFrameworkCore;
using QubitWith.Auth.Data;
using QubitWith.Auth.Data.Models.Entities;
using QubitWith.Auth.Data.Persistence;
using QubitWith.Auth.Data.Persistence.Contracts;

namespace QubitSystem.Persistence
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
