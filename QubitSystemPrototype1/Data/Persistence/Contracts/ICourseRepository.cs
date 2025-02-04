
using QubitSystemPrototype1.Data.Models.Dtos;
using QubitSystemPrototype1.Data.Models.Entities;

namespace QubitSystemPrototype1.Data.Persistence.Contracts

{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        Task<List<CourseDisplayDto>> CourseDisplayAll();

    }
}
