using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppFundamentals.Entities;

namespace AppFundamentals.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(x => x.IdSubject);

            builder
                .Property(x => x.IdSubject)
                .UseIdentityColumn();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(x => x.SubjectStudents)
                .WithOne(y => y.Subject)
                .HasForeignKey(z => z.IdSubject);

            builder
                .ToTable("Subjects");
        }
    }
}
