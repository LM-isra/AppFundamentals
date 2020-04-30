using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFundamentals.Entities;

namespace AppFundamentals.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasKey(x => x.IdTeacher);

            builder
                .Property(x => x.IdTeacher)
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
                .HasMaxLength(12);

            builder
                .Property(x => x.Salary)
                .IsRequired()
                .HasColumnType("decimal");

            builder
                .Property(x => x.Schedule)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
