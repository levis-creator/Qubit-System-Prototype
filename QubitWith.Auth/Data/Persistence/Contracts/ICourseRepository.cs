using QubitWith.Auth.Data.Models.Dtos;
using QubitWith.Auth.Data.Models.Entities;
using QubitWith.Auth.Data.Repositories.Interfaces;

namespace QubitWith.Auth.Data.Persistence.Contracts
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        Task<List<CourseDisplayDto>> CourseDisplayAll();

    }
}
