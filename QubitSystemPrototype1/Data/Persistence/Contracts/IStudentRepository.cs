
using QubitSystemPrototype1.Data.Models.Dtos;
using QubitSystemPrototype1.Data.Models.Entities;

namespace QubitSystemPrototype1.Data.Persistence.Contracts

{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> Add(StudentInputDto entity);
        Task<StudentDetailsDto> GetStudentFullDetails(string Id);
        Task<StudentInputDto> GetStudentFullInputDetails(string Id);
        Task<Student> UpdateStudentInputDetails(StudentInputDto entity);


    }
}
