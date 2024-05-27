using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(128);
            builder.HasMany(x => x.Childs)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId);
        }
    }
    }

