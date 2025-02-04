using QubitSys.Data;
using QubitSys.Models.Entities;
using QubitSys.Persistence.Contracts;

namespace QubitSys.Persistence
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataDbContext context) : base(context)
        {
        }

    }
}
