using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.DAL.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(a => a.About)
               .HasMaxLength(2048);
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(a => a.AuthorizedPerson)
                .IsRequired()
               .HasMaxLength(64);
            builder.Property(a => a.Website)
                .IsRequired()
                ///TODO: belke 2048 e deisdim (dto lari unutma)
                .HasMaxLength(256);
            
            ///TODO:Delete no action arasdir
            builder.HasOne(x => x.User)
                  .WithMany(u => u.Companies)
                  .HasForeignKey(x => x.UserId)
                  .OnDelete(DeleteBehavior.NoAction);
            
            //builder.HasOne(x => x.Email)
            //      .WithMany(u => u.Companies)
            //      .HasForeignKey(x => x.EmailId)
            //      .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(x => x.Phone)
            //      .WithMany(u => u.Companies)
            //      .HasForeignKey(x => x.PhoneId)
            //      .OnDelete(DeleteBehavior.NoAction);
            //builder.HasMany(x=>x.Vacancies)
            //    .WithOne(y=>y.Company)
            //    .HasForeignKey(x=>x.CompanyId)
            //      .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
