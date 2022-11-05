using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlannabelleClassLibrary.ViewModels
{
    public class ViewAllSemestersViewModel : BaseViewModel
    {
        //public ObservableCollection<Semester> Semesters { get; set; }
        public EnrollmentDataService EnrollmentDataService { get; set; }

        public ViewAllSemestersViewModel() : base()
        {
            EnrollmentDataService = new EnrollmentDataService(PlannabelleContextDbFactory.GetDbContext());
            //semesters = new ObservableCollection<Semester>(EnrollmentDataService.getUserSemesters(User.Id));
        }

        public void SemesterSelected(int semesterIndex)
        {
             currentSemesterIndex = semesterIndex;
            base.CurrentSemester = semesters[semesterIndex];
        }
    }
}
