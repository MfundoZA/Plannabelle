using PlannabelleClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.ViewModels
{
    public class ModuleViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int ClassHoursPerWeek { get; set; }
        public int SelfStudyHoursPerWeek { get; set; }
        public double SelfStudyHoursRemainingForWeek { get; set; }
        public IEnumerable<UserModule>? UserModules { get; set; }


        public double calculateSelfStudyHours(int numberOfCredits, Semester selectedSemester, int numberOfClassHours)
        {
            return Math.Ceiling(numberOfCredits * 10 / ((selectedSemester.EndDate - selectedSemester.StartDate).TotalDays / 7) - numberOfClassHours);
        }

        public double calculateSelfStudyHours(int numberOfCredits, double numberOfWeeks, int numberOfClassHours)
        {
            return Math.Ceiling((numberOfCredits * 10d) / numberOfWeeks - numberOfClassHours);
        }
    }
}
