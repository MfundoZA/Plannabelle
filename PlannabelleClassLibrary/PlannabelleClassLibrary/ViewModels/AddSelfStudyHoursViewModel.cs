using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlannabelleClassLibrary.ViewModels 
{
    public class AddSelfStudyHoursViewModel : BaseViewModel
    {
        public Dictionary<int, string> moduleDictionary { get; set; }
        public EnrollmentDataService EnrollmentDataService { get; set; }

        public AddSelfStudyHoursViewModel()
        {
            moduleDictionary = new Dictionary<int, string>();
            EnrollmentDataService = new EnrollmentDataService(PlannabelleContextDbFactory.GetDbContext());

            // Only returns 
            var modules = EnrollmentDataService.getUserModules(User.Id);

            foreach (Module module in modules)
            {
                moduleDictionary.Add(module.Id, module.Name);
            }
        }

        public bool UpdateSelfStudyHours(int moduleId, double hoursStudied)
        {
            Enrollment enrollment = EnrollmentDataService.getAll().FirstOrDefault(x => x.Module.Id == moduleId && x.User.Id == User.Id);

            if (hoursStudied >= enrollment.SelfStudyHoursRemainingForWeek)
            {
                enrollment.SelfStudyHoursRemainingForWeek = 0;
            }
            else
            {
                enrollment.SelfStudyHoursRemainingForWeek -= hoursStudied;
            }

            EnrollmentDataService.dbContext.Update(enrollment);
            EnrollmentDataService.dbContext.SaveChanges();
            
            return true;
        }
    }
}
