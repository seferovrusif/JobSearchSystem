using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.DAL.Configuration
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.Property(a => a.Position)
                .IsRequired()
                .HasMaxLength(128);
            builder.Property(a => a.AboutWork)
                .IsRequired()
                .HasMaxLength(1024);
            builder.Property(a => a.Requirements)
                .IsRequired()
                .HasMaxLength(1024);
            builder.Property(a => a.MaxYas)
                .HasDefaultValue(65)
                ///TODO: deqiqlesdir
                .HasMaxLength(65);
            builder.Property(a => a.MinYas)
                .HasDefaultValue(18)
                ///TODO: deqiqlesdir
                .HasMaxLength(18);
            builder.Property(a => a.AuthorizedPerson)
                .HasMaxLength(64);
            builder.Property(a => a.DeadLine)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(a => a.LastActiveTime)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(a => a.Website)
                .HasMaxLength(256);


            builder.HasOne(x => x.Email)
                 .WithMany(u => u.Vacancies)
                 .HasForeignKey(x => x.EmailId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Phone)
                 .WithMany(u => u.Vacancies)
                 .HasForeignKey(x => x.PhoneId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Company)
                 .WithMany(u => u.Vacancies)
                 .HasForeignKey(x => x.CompanyId);

            builder.HasOne(x => x.Category)
               .WithMany(u => u.Vacancies)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne(x => x.MinSalary)
            //   .WithMany(u => u.Vacancies)
            //   .HasForeignKey(x => x.MinSalaryId)
            //   .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(x => x.MaxSalary)
               .WithMany(u => u.Vacancies)
               .HasForeignKey(x => x.MaxSalaryId)
               .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(x => x.Gender)
               .WithMany(u => u.Vacancies)
               .HasForeignKey(x => x.GenderId)
               .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(x => x.Education)
               .WithMany(u => u.Vacancies)
               .HasForeignKey(x => x.EducationId)
               .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(x => x.ExperienceYear)
               .WithMany(u => u.Vacancies)
               .HasForeignKey(x => x.ExperienceYearId)
               .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(x => x.City)
               .WithMany(u => u.Vacancies)
               .HasForeignKey(x => x.CityId)
               .OnDelete(DeleteBehavior.NoAction);
            
            builder.HasOne(x => x.TypeOfVacancy)
               .WithMany(u => u.Vacancies)
               .HasForeignKey(x => x.TypeOfVacancyId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.WorkType)
               .WithMany(u => u.Vacancies)
               .HasForeignKey(x => x.WorkTypeId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
