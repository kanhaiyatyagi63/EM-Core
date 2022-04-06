using EM.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EM.DataLayer.EntitiesConfiguration
{
    public class EmployeeLanguageConfiguration : IEntityTypeConfiguration<EmployeeLanguage>
    {
        public void Configure(EntityTypeBuilder<EmployeeLanguage> builder)
        {
            builder.ToTable("EmployeeLanguages");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.EmployeeLanguages)
                   .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.Language)
                  .WithMany(x => x.EmployeeLanguages)
                  .HasForeignKey(x => x.LanguageId);
        }
    }
}
