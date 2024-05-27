using JobSearch.Core.Entities;
using JobSearch.Core.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.DAL.Contexts
{
    public class JobSearchContext : IdentityDbContext
    {
        public JobSearchContext(DbContextOptions options) : base(options){}
        public DbSet<AppUser> Users { get; set; }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ExperienceYear> ExperienceYears { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<TypeOfVacancy> TypesOfVacancy { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<JobSeeker> Seekers { get; set; }
        public DbSet<SocialMediaCompany> SocialMediasCompanies { get; set; }
        public DbSet<SocialMediaJobSeeker> SocialMediasJobSeeker { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedTime = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
