using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlannabelleClassLibrary.Models;

namespace Plannabelle_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=tcp:simple-ser.database.windows.net,1433;Initial Catalog=plannabelle-db;Persist Security Info=False;User ID=adm10117299;Password=Landseen76;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }



        /*
        * Domain Introduction and Entity Framework Setup - FULL STACK WPF (.NET CORE) MVVM #1 – SingletonSean.
        * 2019. YouTube video. [Online]. Available at:
        * https://www.youtube.com/watch?v=V9UdD96iTbk&list=PLcV1Ec2giuEjQZNp_2BqmyuxakOYETvEl&index=8.
        */
        public DbSet<UserSemester> UserSemesters { get; set; }
        public DbSet<UserModule> UserModules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}