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

            // Job ↔ Skill (Many-to-Many through RequiredSkill)
            modelBuilder.Entity<RequiredSkill>()
                .HasKey(rs => new { rs.JobId, rs.SkillId });

            modelBuilder.Entity<RequiredSkill>()
                .HasOne(rs => rs.Job)
                .WithMany(j => j.JobSkills)
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
        }
    }
}
