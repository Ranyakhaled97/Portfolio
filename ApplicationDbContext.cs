using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PortfolioProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // configures many-to-many relationship
            modelBuilder.Entity<UserUniversity>().HasKey(x => new { x.UniversityId, x.DegreeId, x.UserId });
            modelBuilder.Entity<UserUniversity>()
            .HasOne<University>(s => s.University)
            .WithMany(x => x.UserUniversities)
            .HasForeignKey(s => s.UniversityId);

            modelBuilder.Entity<UserUniversity>()
            .HasOne<Degree>(s => s.Degree)
            .WithMany(x => x.UserUniversitys)
            .HasForeignKey(s => s.DegreeId);

            modelBuilder.Entity<UserUniversity>()
            .HasOne<User>(s => s.User)
            .WithMany(x => x.UserUniversitys)
            .HasForeignKey(s => s.UserId);

            // configures many-to-many relationship
            modelBuilder.Entity<UserInterpersonalSkill>().HasKey(x => new { x.InterpersonalSkillId, x.UserId });
            modelBuilder.Entity<UserInterpersonalSkill>()
            .HasOne<User>(s => s.user)
            .WithMany(x => x.userInterpersonalSkills)
            .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<UserInterpersonalSkill>()
            .HasOne<InterpersonalSkill>(s => s.interpersonalSkill)
            .WithMany(x => x.userInterpersonalSkills)
            .HasForeignKey(s => s.InterpersonalSkillId);


            // configures many-to-many relationship
            modelBuilder.Entity<UserTechnicalSkill>().HasKey(x => new { x.TechnicalSkillId, x.UserId });
            modelBuilder.Entity<UserTechnicalSkill>()
            .HasOne<User>(s => s.user)
            .WithMany(x => x.userTechnicalSkills)
            .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<UserTechnicalSkill>()
            .HasOne<TechnicalSkill>(s => s.technicalSkill)
            .WithMany(x => x.userTechnicalSkills)
            .HasForeignKey(s => s.TechnicalSkillId);


            // configures one-to-many relationship
            modelBuilder.Entity<Project>()
             .HasOne<User>(b => b.User)
             .WithMany(a => a.Projects)
             .HasForeignKey(b => b.UserId);
        }


        public DbSet<University> Universities { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<UserUniversity> UserUniversities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TechnicalSkill> TechnicalSkills { get; set; }
        public DbSet<InterpersonalSkill> InterpersonalSkills { get; set; }
        public DbSet<UserInterpersonalSkill> UserInterpersonalSkills { get; set; }
        public DbSet<UserTechnicalSkill> UserTechnicalSkills { get; set; }
    }
}
