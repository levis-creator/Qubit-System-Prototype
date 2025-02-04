using Microsoft.EntityFrameworkCore;
using QubitSys.Models.Entities;

namespace QubitSys.Data
{
    public class DataDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Course unique Key
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode).IsUnique();
            //Course relationship
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
            //Student relations
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Courses).WithMany(c => c.Students)
                .UsingEntity<CourseRegistration>(
                l => l.HasOne<Course>().WithMany().HasForeignKey(e => e.CourseId),
                r => r.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentId)
                );
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.AdmissionNo).IsUnique();
        }
    }
}
