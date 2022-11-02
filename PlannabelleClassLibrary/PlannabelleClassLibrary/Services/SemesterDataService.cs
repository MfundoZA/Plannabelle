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
    public class SemesterDataService
    {
        /*
         * API Service Calls and Async ViewModel Loading - FULL STACK WPF (.NET CORE) MVVM #4 – SingletonSean.
         * 2019. YouTube video. [Online]. Available at:
         * https://youtu.be/0SCKUine6tY?t=72
         */
        public PlannabelleDbContext dbContext { get; set; }

        public SemesterDataService(PlannabelleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Semester> getAll()
        {
            var semesters = dbContext.Semester;

            return semesters;
        }

        async Task<Semester> Get(int id)
        {
            Semester semester = await dbContext.Semester
                .FirstOrDefaultAsync(s => s.Id == id);

            return semester;
        }

        public bool Insert(Semester semester)
        {
            EntityEntry<Semester> newSemester = dbContext.Set<Semester>().Add(semester);
            dbContext.SaveChangesAsync();

            return true;
        }

        async Task<Semester> Update(int id, Semester semester)
        {
            semester.Id = id;

            dbContext.Set<Semester>().Update(semester);
            await dbContext.SaveChangesAsync();

            return semester;
        }

        public async Task<bool> Delete(int id)
        {
            Semester semester = await dbContext.Set<Semester>().FirstOrDefaultAsync(s => s.Id == id);
            dbContext.Set<Semester>().Remove(semester);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
