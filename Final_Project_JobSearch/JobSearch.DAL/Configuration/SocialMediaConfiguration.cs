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
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(a => a.MainLink)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(a => a.Icon)
                .IsRequired()
                .HasMaxLength(128);


        }

    }
}
