
using QubitWith.Auth.Data.Models.Dtos;
using QubitWith.Auth.Data.Models.Entities;
using QubitWith.Auth.Data.Repositories.Interfaces;

namespace QubitWith.Auth.Data.Persistence.Contracts
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> Add(StudentInputDto entity);
        Task<StudentDetailsDto> GetStudentFullDetails(int Id);
        Task<StudentInputDto> GetStudentFullInputDetails(int Id);
        Task<Student> UpdateStudentInputDetails(StudentInputDto entity);


    }
}
