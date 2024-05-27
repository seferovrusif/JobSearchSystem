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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(b => b.Surname)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(b => b.BirthDate)
                .IsRequired()
                .HasColumnType("date");
            /////TODO: bax burda yazdiqlarim elave edir yoxsa silib yerine yazir 
            //builder.Property(b => b.UserName)
            //    .IsRequired()
            //    .HasMaxLength(64);
        }
    }
}
