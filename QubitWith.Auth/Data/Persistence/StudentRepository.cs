using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QubitWith.Auth.Data.Models.Dtos;
using QubitWith.Auth.Data.Models.Entities;
using QubitWith.Auth.Data.Persistence.Contracts;

namespace QubitWith.Auth.Data.Persistence
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly IMapper mapper;
        public StudentRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }
        public async Task<Student> Add(StudentInputDto entity)
        {
            var student = mapper.Map<Student>(entity);
            var courses = new List<Course>();
            Course? course = await context.Courses.FirstOrDefaultAsync(x => x.Id == entity.CoursesId);
            courses.Add(course!);
            student.Courses = courses;
            await context.AddAsync(student);
            await context.SaveChangesAsync();
            return student;
        }

        public async Task<StudentDetailsDto> GetStudentFullDetails(int Id)
        {
            var student = await context.Students.Include(i => i.Courses).FirstOrDefaultAsync(x => x.Id == Id);
            var studentDto = mapper.Map<StudentDetailsDto>(student);
            var courses = student?.Courses;
            var courseDto = mapper.Map<List<CourseDisplayDto>>(courses);
            studentDto.Courses = courseDto;
            return studentDto;
        }
        public async Task<StudentInputDto> GetStudentFullInputDetails(int Id)
        {
            var student = await context.Students.Include(i => i.Courses).FirstOrDefaultAsync(x => x.Id == Id);
            var studentDto = mapper.Map<StudentInputDto>(student);
            return studentDto;
        }

        public async Task<Student> UpdateStudentInputDetails(StudentInputDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

            // Validate the presence of the 'Id' property and retrieve its value
            var idProperty = entity.GetType().GetProperty("Id");
            if (idProperty == null)
                throw new ArgumentException("Entity does not have an 'Id' property.");

            if (!(idProperty.GetValue(entity) is int Id))
                throw new InvalidCastException("The 'Id' property is not of type 'int'.");

            // Find the existing entity in the database
            var existingEntity = await context.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == Id);

            if (existingEntity == null)
                throw new KeyNotFoundException($"Entity with ID {Id} not found for update.");

            // Use AutoMapper to map the fields from DTO to the existing entity
            mapper.Map(entity, existingEntity);

            // Handle Courses separately
            if (entity.CoursesId != null)
            {
                var course = await context.Courses.FindAsync(entity.CoursesId);
                if (course == null)
                    throw new KeyNotFoundException($"Course with ID {entity.CoursesId} not found.");

                existingEntity.Courses = new List<Course> { course };
            }
            else
            {
                existingEntity.Courses = new List<Course>(); // Clear courses if no ID is provided
            }

            // Save changes
            try
            {
                await context.SaveChangesAsync();
                return existingEntity!;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.Error.WriteLine($"Concurrency error: {ex.Message}");
                throw new Exception("A concurrency error occurred while updating the entity.", ex);
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine($"Database update error: {ex.Message}");
                throw new Exception("An error occurred while updating the entity in the database.", ex);
            }
        }
    }
}
