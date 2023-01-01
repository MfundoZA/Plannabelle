using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PlannabelleClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.Data
{
    public class PlannabelleDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; } = null!;
        public DbSet<Semester> Semesters { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Enrollment> Enrollments { get; set; } = null!;

        public PlannabelleDbContext()
        {
        }

        public PlannabelleDbContext(DbContextOptions<PlannabelleDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:simple-ser.database.windows.net,1433;Initial Catalog=plannabelle-db;Persist Security Info=False;User ID=adm10117299;Password=Landseen76;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
    }
}
