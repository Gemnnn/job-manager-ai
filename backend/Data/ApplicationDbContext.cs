using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<RequiredSkill> RequiredSkills { get; set; }
        public DbSet<JobBenefit> JobBenefits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Job ↔ JobDescription (1:1)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.JobDescription)
                .WithOne(d => d.Job)
                .HasForeignKey<Job>(j => j.JobDescriptionId)
                .OnDelete(DeleteBehavior.SetNull);

            // User ↔ Job (1:N)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.User)
                .WithMany(u => u.Jobs)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Job ↔ Location (N:1)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Location)
                .WithMany(l => l.Jobs)
                .HasForeignKey(j => j.LocationId)
                .OnDelete(DeleteBehavior.SetNull);

            // Location ↔ City (N:1)
            modelBuilder.Entity<Location>()
                .HasOne(l => l.City)
                .WithMany(c => c.Locations)
                .HasForeignKey(l => l.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            // City ↔ Province (N:1)
            modelBuilder.Entity<City>()
                .HasOne(c => c.Province)
                .WithMany(p => p.Cities)
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Province ↔ Country (N:1)
            modelBuilder.Entity<Province>()
                .HasOne(p => p.Country)
                .WithMany(c => c.Provinces)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Job ↔ Industry (N:1)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Industry)
                .WithMany(i => i.Jobs)
                .HasForeignKey(j => j.IndustryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Job ↔ Department (N:1)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Department)
                .WithMany(d => d.Jobs)
                .HasForeignKey(j => j.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // Job ↔ Skill (Many-to-Many through RequiredSkill)
            modelBuilder.Entity<RequiredSkill>()
                .HasKey(rs => new { rs.JobId, rs.SkillId });

            modelBuilder.Entity<RequiredSkill>()
                .HasOne(rs => rs.Job)
                .WithMany(j => j.RequiredSkill)
                .HasForeignKey(rs => rs.JobId);

            modelBuilder.Entity<RequiredSkill>()
                .HasOne(rs => rs.Skill)
                .WithMany(s => s.RequiredSkills)
                .HasForeignKey(rs => rs.SkillId);

            // Job ↔ Benefit (Many-to-Many through JobBenefit)
            modelBuilder.Entity<JobBenefit>()
                .HasKey(jb => new { jb.JobId, jb.BenefitId });

            modelBuilder.Entity<JobBenefit>()
                .HasOne(jb => jb.Job)
                .WithMany(j => j.JobBenefits)
                .HasForeignKey(jb => jb.JobId);

            modelBuilder.Entity<JobBenefit>()
                .HasOne(jb => jb.Benefit)
                .WithMany(b => b.JobBenefits)
                .HasForeignKey(jb => jb.BenefitId);


            // Seeding initial data

            // Counrties Seed Data
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Canada" },
                new Country { Id = 2, Name = "United States" }
            );

            // Provinces Seed Data

            // Province Seed: Canada (ID: 101–120)
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 101, Name = "Alberta", CountryId = 1 },
                new Province { Id = 102, Name = "British Columbia", CountryId = 1 },
                new Province { Id = 103, Name = "Manitoba", CountryId = 1 },
                new Province { Id = 104, Name = "New Brunswick", CountryId = 1 },
                new Province { Id = 105, Name = "Newfoundland and Labrador", CountryId = 1 },
                new Province { Id = 106, Name = "Nova Scotia", CountryId = 1 },
                new Province { Id = 107, Name = "Ontario", CountryId = 1 },
                new Province { Id = 108, Name = "Prince Edward Island", CountryId = 1 },
                new Province { Id = 109, Name = "Quebec", CountryId = 1 },
                new Province { Id = 110, Name = "Saskatchewan", CountryId = 1 },
                new Province { Id = 111, Name = "Northwest Territories", CountryId = 1 },
                new Province { Id = 112, Name = "Nunavut", CountryId = 1 },
                new Province { Id = 113, Name = "Yukon", CountryId = 1 }
            );

            // Province Seed: United States (ID: 201–220)
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 201, Name = "Alabama", CountryId = 2 },
                new Province { Id = 202, Name = "Alaska", CountryId = 2 },
                new Province { Id = 203, Name = "Arizona", CountryId = 2 },
                new Province { Id = 204, Name = "Arkansas", CountryId = 2 },
                new Province { Id = 205, Name = "California", CountryId = 2 },
                new Province { Id = 206, Name = "Colorado", CountryId = 2 },
                new Province { Id = 207, Name = "Connecticut", CountryId = 2 },
                new Province { Id = 208, Name = "Delaware", CountryId = 2 },
                new Province { Id = 209, Name = "Florida", CountryId = 2 },
                new Province { Id = 210, Name = "Georgia", CountryId = 2 },
                new Province { Id = 211, Name = "Hawaii", CountryId = 2 },
                new Province { Id = 212, Name = "Idaho", CountryId = 2 },
                new Province { Id = 213, Name = "Illinois", CountryId = 2 },
                new Province { Id = 214, Name = "Indiana", CountryId = 2 },
                new Province { Id = 215, Name = "Iowa", CountryId = 2 },
                new Province { Id = 216, Name = "Kansas", CountryId = 2 },
                new Province { Id = 217, Name = "Kentucky", CountryId = 2 },
                new Province { Id = 218, Name = "Louisiana", CountryId = 2 },
                new Province { Id = 219, Name = "Maine", CountryId = 2 },
                new Province { Id = 220, Name = "Maryland", CountryId = 2 },
                new Province { Id = 221, Name = "Massachusetts", CountryId = 2 },
                new Province { Id = 222, Name = "Michigan", CountryId = 2 },
                new Province { Id = 223, Name = "Minnesota", CountryId = 2 },
                new Province { Id = 224, Name = "Mississippi", CountryId = 2 },
                new Province { Id = 225, Name = "Missouri", CountryId = 2 },
                new Province { Id = 226, Name = "Montana", CountryId = 2 },
                new Province { Id = 227, Name = "Nebraska", CountryId = 2 },
                new Province { Id = 228, Name = "Nevada", CountryId = 2 },
                new Province { Id = 229, Name = "New Hampshire", CountryId = 2 },
                new Province { Id = 230, Name = "New Jersey", CountryId = 2 },
                new Province { Id = 231, Name = "New Mexico", CountryId = 2 },
                new Province { Id = 232, Name = "New York", CountryId = 2 },
                new Province { Id = 233, Name = "North Carolina", CountryId = 2 },
                new Province { Id = 234, Name = "North Dakota", CountryId = 2 },
                new Province { Id = 235, Name = "Ohio", CountryId = 2 },
                new Province { Id = 236, Name = "Oklahoma", CountryId = 2 },
                new Province { Id = 237, Name = "Oregon", CountryId = 2 },
                new Province { Id = 238, Name = "Pennsylvania", CountryId = 2 },
                new Province { Id = 239, Name = "Rhode Island", CountryId = 2 },
                new Province { Id = 240, Name = "South Carolina", CountryId = 2 },
                new Province { Id = 241, Name = "South Dakota", CountryId = 2 },
                new Province { Id = 242, Name = "Tennessee", CountryId = 2 },
                new Province { Id = 243, Name = "Texas", CountryId = 2 },
                new Province { Id = 244, Name = "Utah", CountryId = 2 },
                new Province { Id = 245, Name = "Vermont", CountryId = 2 },
                new Province { Id = 246, Name = "Virginia", CountryId = 2 },
                new Province { Id = 247, Name = "Washington", CountryId = 2 },
                new Province { Id = 248, Name = "West Virginia", CountryId = 2 },
                new Province { Id = 249, Name = "Wisconsin", CountryId = 2 },
                new Province { Id = 250, Name = "Wyoming", CountryId = 2 },
                new Province { Id = 251, Name = "District of Columbia", CountryId = 2 }
            );
        }
    }
}
