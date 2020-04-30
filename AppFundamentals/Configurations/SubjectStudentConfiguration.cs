using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFundamentals.Entities;

namespace AppFundamentals.Configurations
{
    public class SubjectStudentConfiguration : IEntityTypeConfiguration<SubjectStudent>
    {
        public void Configure(EntityTypeBuilder<SubjectStudent> builder)
        {
            builder
                .HasKey(x => new { x.IdSubject, x.IdStudent });

            builder
                .Property(x => x.State)
                .IsRequired()
                .HasMaxLength(12);

            builder
                .Property(x => x.Note)
                .IsRequired()
                .HasColumnType("decimal");

            builder
                .HasOne(x => x.Subject)
                .WithMany(y => y.SubjectStudents)
                .HasForeignKey(z => z.IdSubject);

            builder
                .HasOne(x => x.Student)
                .WithMany(y => y.SubjectStudents)
                .HasForeignKey(z => z.IdStudent);

            builder
                .ToTable("SubjectsStudents");

        }
    }
}
