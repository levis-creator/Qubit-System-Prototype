using QubitSystem.Models.Dtos;
using QubitSystem.Models.Entities;
using QubitSystem.Repositories.Interfaces;

namespace QubitSystem.Persistence.Contracts
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        Task<List<CourseDisplayDto>> CourseDisplayAll();

    }
}
