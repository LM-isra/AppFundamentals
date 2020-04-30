using Microsoft.EntityFrameworkCore;
using AppFundamentals.Entities;
using AppFundamentals.Configurations;

namespace AppFundamentals.Contexts
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HostedServiceLog> HostedServiceLogs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectStudent> SubjectsStudents { get; set; }
        public DbSet<SubjectTeacher> SubjectsTeachers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new SubjectConfiguration());
            builder.ApplyConfiguration(new SubjectStudentConfiguration());
            builder.ApplyConfiguration(new SubjectTeacherConfiguration());
            builder.ApplyConfiguration(new TeacherConfiguration());
        }
    }
}
