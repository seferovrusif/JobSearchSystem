using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.DAL.Configuration
{
    public class TypeOfVacancyConfiguration: IEntityTypeConfiguration<TypeOfVacancy>
    {
        public void Configure(EntityTypeBuilder<TypeOfVacancy> builder)
        {
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}