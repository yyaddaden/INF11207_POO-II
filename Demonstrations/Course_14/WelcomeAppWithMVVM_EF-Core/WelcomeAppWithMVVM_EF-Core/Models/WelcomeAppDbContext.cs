using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WelcomeAppWithMVVM_EF_Core.Models
{
    class WelcomeAppDbContext : DbContext
    {
        public DbSet<Greeting> Greetings { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=WelcomeAppDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
            new Job() { JobId = 1, Title = "Étudiant" },
            new Job() { JobId = 2, Title = "Ingénieur" },
            new Job() { JobId = 3, Title = "Professeur" },
            new Job() { JobId = 4, Title = "Directeur" }
            );
        }
    }
}
