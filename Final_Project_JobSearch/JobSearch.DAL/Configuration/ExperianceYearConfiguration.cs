using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.DAL.Configuration
{
    public class ExperianceYearConfiguration:IEntityTypeConfiguration<ExperienceYear>
    {
        public void Configure(EntityTypeBuilder<ExperienceYear> builder)
        {

            builder.Property(a => a.ExpYear)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}

