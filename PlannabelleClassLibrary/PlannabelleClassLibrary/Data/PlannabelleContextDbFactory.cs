using System;
using System.Collections.Generic;
using System.Text;

namespace PlannabelleClassLibrary.Data
{
   /*
    * Domain Introduction and Entity Framework Setup - FULL STACK WPF (.NET CORE) MVVM #1 – SingletonSean.
    * 2019. YouTube video. [Online]. Available at:
    * https://www.youtube.com/watch?v=V9UdD96iTbk&list=PLcV1Ec2giuEjQZNp_2BqmyuxakOYETvEl&index=8.
    */
    public class PlannabelleContextDbFactory
    {
        private static PlannabelleDbContext DbContext;

        // Using singleton pattern to avoid conflicting DbContexts
        public static PlannabelleDbContext GetDbContext()
        {
            if (DbContext == null)
            {
                DbContext = new PlannabelleDbContext();
            }

            return DbContext;
        }
    }
}
