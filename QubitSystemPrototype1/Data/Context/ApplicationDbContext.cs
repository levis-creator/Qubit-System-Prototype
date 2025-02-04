using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QubitSystemPrototype1.Data.Models.Common;
using QubitSystemPrototype1.Data.Models.Entities;

namespace QubitSystemPrototype1.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
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
