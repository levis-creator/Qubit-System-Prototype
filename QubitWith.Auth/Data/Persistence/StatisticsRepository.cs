using Microsoft.EntityFrameworkCore;
using QubitWith.Auth.Data.Models.Entities.Statistics;
using QubitWith.Auth.Data.Persistence.Contracts;

namespace QubitWith.Auth.Data.Persistence
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly ApplicationDbContext context;

        public StatisticsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<StatisticsAdmin> GetAdminStatistics()
        {
            var studentsCount = await context.Students.CountAsync();
            var departmentCount = await context.Departments.CountAsync();
            var coursesCount = await context.Courses.CountAsync(); // Fixed: Fetch from Courses, not Departments

            return new StatisticsAdmin
            {
                StudentsTotal = studentsCount,
                CourseCount = coursesCount,
                DepartmentCount = departmentCount
            };
        }
    }
}
