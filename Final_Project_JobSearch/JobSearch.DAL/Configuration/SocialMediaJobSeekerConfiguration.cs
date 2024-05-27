using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.DAL.Configuration
{
    public class SocialMediaJobSeekerConfiguration : IEntityTypeConfiguration<SocialMediaJobSeeker>
    {
        public void Configure(EntityTypeBuilder<SocialMediaJobSeeker> builder)
        {
            builder.Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasOne(x => x.SocialMedia)
                 .WithMany(u => u.SocialMediaJobSeekers)
                 .HasForeignKey(x => x.SocialMediaId)
                 .OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne(x => x.JobSeeker)
                 .WithMany(u => u.SocialMediaJobSeekers)
                 .HasForeignKey(x => x.JobSeekerId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
