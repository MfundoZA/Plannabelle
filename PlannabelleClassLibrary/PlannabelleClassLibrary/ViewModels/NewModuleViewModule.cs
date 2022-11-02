using Microsoft.EntityFrameworkCore;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlannabelleClassLibrary.ViewModels
{
    public class NewModuleViewModel : BaseViewModel
    {
        /*  Stack Overflow. 2017. How To Bind a Combobox to a Dictionary in WPF C#,
        *  24 May 2017. [Online]. Available at:
        *  https://stackoverflow.com/questions/44146942/how-to-bind-a-combobox-to-a-dictionary-in-wpf-c-sharp
        *  [Accessed 18 October 2022].
        */
        public Dictionary<int, string> semesterDictionary { get; set; }
        public ModuleDataService ModuleDataService { get; set; }
        public EnrollmentDataService EnrollmentDataService { get; set; }
        public SemesterDataService SemesterDataService { get; set; }

        public NewModuleViewModel()
        {
            semesterDictionary = new Dictionary<int, string>();
            ModuleDataService = new ModuleDataService(PlannabelleContextDbFactory.GetDbContext());
            EnrollmentDataService = new EnrollmentDataService(PlannabelleContextDbFactory.GetDbContext());
            SemesterDataService = new SemesterDataService(PlannabelleContextDbFactory.GetDbContext());


            var semesters = EnrollmentDataService.getUserSemesters(User.Id);

            foreach (Semester semester in semesters)
            {
                semesterDictionary.Add(semester.Id, semester.StartDate.ToLongDateString() + " - " + semester.EndDate.ToLongDateString());
            }
        }

        public bool WriteModuleToDatabase(Module module)
        {
            ModuleDataService.Insert(module);

            return true;
        }

        public bool WriteEnrollmentToDatabase(Enrollment enrollment)
        {
            EnrollmentDataService.Insert(enrollment);

            return true;
        }

        public double calculateSelfStudyHours(int numberOfCredits, Semester selectedSemester, int numberOfClassHours)
        {
            return Math.Ceiling(numberOfCredits * 10 / (selectedSemester.EndDate - selectedSemester.StartDate).TotalDays - numberOfClassHours);
        }
    }
}
