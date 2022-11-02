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

        public bool WriteSemesterToDatabase(Semester newSemester)
        {
            SemesterDataService.Insert(newSemester);

            return true;
        }
    }
}
