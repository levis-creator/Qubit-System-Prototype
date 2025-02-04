using Microsoft.EntityFrameworkCore;
using QubitSys.Data;
using QubitSys.Models.Entities;
using QubitSys.Persistence.Contracts;
using QubitSys.Repositories.Interfaces;

namespace QubitSys.Persistence
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataDbContext context) : base(context)
        {
        }
    }
}
