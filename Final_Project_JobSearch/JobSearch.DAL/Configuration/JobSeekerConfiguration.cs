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
    public class JobSeekerConfiguration : IEntityTypeConfiguration<JobSeeker>
    {
        public void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            builder.Property(a => a.Skills)
                .HasMaxLength(1024);
            builder.Property(a => a.LanguageSkills)
                .HasMaxLength(512);
            builder.Property(a => a.Position)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(a => a.Surname)
                            .IsRequired()
                .HasMaxLength(32);
            builder.Property(a => a.FatherName)
                            .IsRequired()
                .HasMaxLength(32);
            builder.Property(a => a.AdditionalInformation)
               .HasMaxLength(1024);
            builder.Property(a => a.BirthDate)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(a => a.LastActiveTime)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(a => a.ExperienceDetail)
                .IsRequired().
                HasMaxLength(1024);
            builder.Property(a => a.EducationDetail)
                            .IsRequired().
                            HasMaxLength(1024);
            builder.Property(a => a.CVImgUrl)
                .HasMaxLength(64);
            builder.Property(a => a.ImageUrl)
                .HasMaxLength(64);



            builder.HasOne(x => x.User)
           .WithMany(u => u.Seekers)
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Email)
                 .WithMany(u => u.Seekers)
                 .HasForeignKey(x => x.EmailId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Phone)
                 .WithMany(u => u.Seekers)
                 .HasForeignKey(x => x.PhoneId)
                 .OnDelete(DeleteBehavior.NoAction);

       
            builder.HasOne(x => x.Category)
               .WithMany(u => u.Seekers)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);
        
            builder.HasOne(x => x.Gender)
               .WithMany(u => u.Seekers)
               .HasForeignKey(x => x.GenderId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Education)
               .WithMany(u => u.Seekers)
               .HasForeignKey(x => x.EducationId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ExperienceYear)
               .WithMany(u => u.Seekers)
               .HasForeignKey(x => x.ExperienceYearId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.City)
               .WithMany(u => u.Seekers)
               .HasForeignKey(x => x.CityId)
               .OnDelete(DeleteBehavior.NoAction);

           
        }
    }
}
