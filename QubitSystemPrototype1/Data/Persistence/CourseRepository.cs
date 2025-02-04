using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QubitSystemPrototype1.Data.Context;
using QubitSystemPrototype1.Data.Models.Dtos;
using QubitSystemPrototype1.Data.Models.Entities;
using QubitSystemPrototype1.Data.Persistence.Contracts;


namespace QubitSystemPrototype1.Data.Persistence
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly IMapper mapper;

        public CourseRepository(ApplicationDbContext context, IMapper _mapper) : base(context)
        {
            mapper = _mapper;
        }

        public async Task<List<CourseDisplayDto>> CourseDisplayAll()
        {
            var courses= await context.Courses.Include(c => c.Department).ToListAsync();
            return mapper.Map<List<CourseDisplayDto>>(courses);
        }

        public override async Task<List<Course>> GetAll()
        {
            return await context.Courses.Include(c => c.Department).ToListAsync();
        }

        public override async Task<Course> GetById(string id)
        {
            try
            {
                // Attempt to find the entity by its primary key
                var course = await context.Courses
                   .Include(c => c.Department)
                   .FirstOrDefaultAsync(c => c.Id == id);

                if (course == null)
                {
                    throw new KeyNotFoundException($"Course with ID {id} not found.");
                }

                return course;
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                throw new Exception("An error occurred while retrieving the course.", ex);
            }
        }
    }
}
