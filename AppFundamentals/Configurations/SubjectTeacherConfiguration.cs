using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFundamentals.Entities;

namespace AppFundamentals.Configurations
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            builder
                .HasKey(x => new { x.IdSubject, x.IdTeacher });

            builder
                .HasOne(x => x.Subject)
                .WithMany(y => y.SubjectTeachers)
                .HasForeignKey(z => z.IdSubject);

            builder
                .HasOne(x => x.Teacher)
                .WithMany(y => y.SubjectTeachers)
                .HasForeignKey(z => z.IdTeacher);

            builder
                .ToTable("SubjectsTeachers");
        }
    }
}
