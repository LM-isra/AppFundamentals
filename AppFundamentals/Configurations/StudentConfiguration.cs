using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFundamentals.Entities;

namespace AppFundamentals.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(x => x.IdStudent);

            builder
                .Property(x => x.IdStudent)
                .UseIdentityColumn();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Birthdate)
                .IsRequired();

            builder
                .Property(x => x.Gender)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Enrollment)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(x => x.SubjectStudents)
                .WithOne(y => y.Student)
                .HasForeignKey(z => z.IdStudent);

            builder
                .ToTable("Students");
        }
    }
}
