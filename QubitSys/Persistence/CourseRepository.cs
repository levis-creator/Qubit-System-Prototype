using Microsoft.EntityFrameworkCore;
using QubitSys.Data;
using QubitSys.Models.Entities;
using QubitSys.Persistence.Contracts;

namespace QubitSys.Persistence
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(DataDbContext context) : base(context)
        {
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
