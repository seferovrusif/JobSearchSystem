using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.DAL.Configuration
{
    public class SocialMediaCompanyConfiguration : IEntityTypeConfiguration<SocialMediaCompany>
    {
        public void Configure(EntityTypeBuilder<SocialMediaCompany> builder)
        {
            builder.Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasOne(x => x.SocialMedia)
                 .WithMany(u => u.SocialMediaCompanies)
                 .HasForeignKey(x => x.SocialMediaId)
                 .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Company)
                 .WithMany(u => u.SocialMediaCompany)
                 .HasForeignKey(x => x.CompanyId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
