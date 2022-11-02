using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlannabelleClassLibrary.Services
{
    /*
     * API Service Calls and Async ViewModel Loading - FULL STACK WPF (.NET CORE) MVVM #4 – SingletonSean.
     * 2019. YouTube video. [Online]. Available at:
     * https://youtu.be/0SCKUine6tY?t=72
     */
    public class EnrollmentDataService
    {
        public PlannabelleDbContext dbContext { get; set; }

        public EnrollmentDataService(PlannabelleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /* Retrieves all enrollments from the database. This can
         *  be useful in future for a stats dashboard on all users
         */ 
        public IEnumerable<Enrollment> getAll()
        {
            var enrollments = (from e in dbContext.Enrollment
                                   select e);

            return enrollments;
        }

        // Retrives all of the current user's enrollments
        public List<Enrollment> getUserEnrollments(int userId)
        {
            var userEnrollments = (from e in dbContext.Enrollment
                                 where e.User.Id == userId
                                 select e).Distinct().ToList();

            return userEnrollments;
        }

        public List<Semester> getUserSemesters(int userId)
        {
            var userSemesters = (from e in dbContext.Enrollment
                                   where e.User.Id == userId
                                   select e.Semester).Distinct().ToList();

            return userSemesters;
        }

        public List<Module> getUserModules(int userId)
        {
            var userModules = (from e in dbContext.Enrollment
                                 where e.User.Id == userId
                                 select e.Module).Distinct().ToList();

            return userModules;
        }

        // Retrieves a specified enrollment using an id
        public Enrollment Get(int id)
        {
            Enrollment enrollment = dbContext.Enrollment
                .FirstOrDefault(e => e.Id == id);

            return enrollment;
        }

        // Create a new enrollment
        public Enrollment Insert(Enrollment enrollment)
        {
            EntityEntry<Enrollment> newEnrollment = dbContext.Set<Enrollment>().Add(enrollment);
            dbContext.SaveChanges();

            return newEnrollment.Entity;
        }

        // Updates an existing enrollment
        public Enrollment Update(int id, Enrollment enrollment)
        {
            enrollment.Id = id;

            dbContext.Set<Enrollment>().Update(enrollment);
            dbContext.SaveChanges();

            return enrollment;
        }

        // Deletes an enrollment
        public bool Delete(int id)
        {
            Enrollment enrollment = dbContext.Set<Enrollment>().FirstOrDefault(e => e.Id == id);
            dbContext.Set<Enrollment>().Remove(enrollment);
            dbContext.SaveChanges();

            return true;
        }
    }
}
