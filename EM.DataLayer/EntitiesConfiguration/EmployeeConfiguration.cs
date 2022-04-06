using EM.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EM.DataLayer.EntitiesConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Gender).HasMaxLength(20);
            builder.Property(x => x.JobTitle).HasMaxLength(50);

            builder.HasOne(x => x.Address)
                   .WithOne(x => x.Employee)
                   .HasForeignKey<Address>(x => x.EmployeeId);

            builder.HasOne(x => x.Department)
                   .WithMany(x => x.Employees)
                   .HasForeignKey(x => x.DepartmentId);

        }
    }
}
