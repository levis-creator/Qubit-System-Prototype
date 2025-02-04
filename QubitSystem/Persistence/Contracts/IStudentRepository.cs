using QubitSystem.Models.Dtos;
using QubitSystem.Models.Entities;
using QubitSystem.Repositories.Interfaces;

namespace QubitSystem.Persistence.Contracts
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> Add(StudentInputDto entity);
        Task<StudentDetailsDto> GetStudentFullDetails(string Id);
        Task<StudentInputDto> GetStudentFullInputDetails(string Id);
        Task<Student> UpdateStudentInputDetails(StudentInputDto entity);


    }
}
