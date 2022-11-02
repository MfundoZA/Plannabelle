using Microsoft.EntityFrameworkCore;
using PlannabelleClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlannabelleClassLibrary.Data
{ 
    public class PlannabelleDbContext : DbContext
    {
        /*
        * Domain Introduction and Entity Framework Setup - FULL STACK WPF (.NET CORE) MVVM #1 – SingletonSean.
        * 2019. YouTube video. [Online]. Available at:
        * https://www.youtube.com/watch?v=V9UdD96iTbk&list=PLcV1Ec2giuEjQZNp_2BqmyuxakOYETvEl&index=8.
        */
        public DbSet<User> User { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:simple-ser.database.windows.net,1433;Initial Catalog=plannabelle-db;Persist Security Info=False;User ID=adm10117299;Password=Landseen76;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
