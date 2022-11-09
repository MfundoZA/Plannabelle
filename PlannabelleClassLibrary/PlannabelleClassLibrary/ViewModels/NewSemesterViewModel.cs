using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.ViewModels
{
    public class NewSemesterViewModel : BaseViewModel
    {
        public SemesterDataService SemesterDataService { get; set; } = new SemesterDataService(PlannabelleContextDbFactory.GetDbContext());
        public EnrollmentDataService EnrollmentDataService { get; set; }// = new EnrollmentDataService(new PlannabelleDbContext());

        public bool WriteSemesterToDatabase(Semester newSemester)
        {
            SemesterDataService.Insert(newSemester);
            SemesterDataService.dbContext.SaveChanges();

            EnrollmentDataService.Insert(new Enrollment(User, null, newSemester, 0, 0, 0));
            EnrollmentDataService.dbContext.SaveChanges();

            return true;
        }
    }
}
