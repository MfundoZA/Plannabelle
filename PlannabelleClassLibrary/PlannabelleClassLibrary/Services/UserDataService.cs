using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.Services
{
    /*
     * API Service Calls and Async ViewModel Loading - FULL STACK WPF (.NET CORE) MVVM #4 – SingletonSean.
     * 2019. YouTube video. [Online]. Available at:
     * https://youtu.be/0SCKUine6tY?t=72
     */
    public class UserDataService
    {
        public PlannabelleDbContext dbContext { get; set; }

        public UserDataService(PlannabelleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<User> getAll()
        {
            var users = dbContext.User.ToList();

            return users;
        }

        public User Get(int id)
        {
            User user = dbContext.User
                .FirstOrDefault(u => u.Id == id);

            return user;
        }

        public User Insert(User user)
        {
            EntityEntry<User> newUser = dbContext.Set<User>().Add(user);
            dbContext.SaveChanges();

            return newUser.Entity;
        }

        public User Update(int id, User user)
        {
            user.Id = id;

            dbContext.Set<User>().Update(user);
            dbContext.SaveChanges();

            return user;
        }

        public bool Delete(int id)
        {
            User user = dbContext.Set<User>().FirstOrDefault(u => u.Id == id);
            dbContext.Set<User>().Remove(user);
            dbContext.SaveChanges();

            return true;
        }
    }
}
