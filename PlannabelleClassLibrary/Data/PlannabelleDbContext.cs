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
        public DbSet<StudentSemester> StudentSemesters { get; set; } = null!;

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
                optionsBuilder.UseSqlServer("Data Source=Jordan\\SQLEXPRESS;Initial Catalog=Plannabelle;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
    }
}
