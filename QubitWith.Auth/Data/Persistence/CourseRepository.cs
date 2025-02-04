using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QubitWith.Auth.Data.Models.Dtos;
using QubitWith.Auth.Data.Models.Entities;
using QubitWith.Auth.Data.Persistence.Contracts;

namespace QubitWith.Auth.Data.Persistence
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

        public override async Task<Course> GetById(int id)
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
