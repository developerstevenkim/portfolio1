using System;
using System.Collections.Generic;
using System.Text;
using Do4.Models;
using DohunKim.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DohunKim.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Project_Language>()
                .HasOne(p => p.Project)
                .WithMany(pl => pl.Project_Languages)
                .HasForeignKey(f => f.ProjectName);
            modelBuilder.Entity<Project_Language>()
                .HasOne(l => l.Language)
                .WithMany(pla => pla.Project_Languages)
                .HasForeignKey(f => f.LanguageName);

            modelBuilder.Entity<Project_Author>()
                .HasOne(p => p.Project)
                .WithMany(pl => pl.Project_Authors)
                .HasForeignKey(f => f.ProjectName);
            modelBuilder.Entity<Project_Author>()
                .HasOne(a => a.Author)
                .WithMany(pla => pla.Project_Authors)
                .HasForeignKey(l => l.AuthorName);


            modelBuilder.Entity<ApplicationType>().HasData(SampleProject.GetApplications());
            // modelBuilder.Entity<Occupation>().HasData(SampleProject.GetOccupations());
            // modelBuilder.Entity<Author>().HasData(SampleProject.GetAuthors());
            // modelBuilder.Entity<Language>().HasData(SampleProject.GetLanguages());
            modelBuilder.Entity<Project>().HasData(SampleProject.GetProjects());
            // modelBuilder.Entity<Project_Author>().HasData(SampleProject.GetProject_Authors());
            // modelBuilder.Entity<Project_Language>().HasData(SampleProject.GetProject_Languages());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Project_Author> Project_Authors { get; set; }
        public DbSet<Project_Language> Project_Languages { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
    }
}
