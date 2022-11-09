using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PlannabelleClassLibrary.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public EnrollmentDataService enrollmentDataService { get; set; }

        private ObservableCollection<Module> modules;

        public ObservableCollection<Module> Modules
        {
            get
            {
                return modules;
            }

            set
            {
                modules = value;
                OnPropertyChanged(nameof(modules));
            }
        }

        public MainViewModel()
        {
            dbContext = PlannabelleContextDbFactory.GetDbContext();
            enrollmentDataService = new EnrollmentDataService(dbContext);
            semesters = new ObservableCollection<Semester>(enrollmentDataService.getUserSemesters(User.Id));

            if (semesters.Count > 0)
            {
                CurrentSemester = semesters.First();
                currentSemesterIndex = 0;
            }
        }

        public bool moveToPreviousSemester()
        {
            bool result = true;

            if (currentSemesterIndex > 0)
            {
                CurrentSemester = semesters[currentSemesterIndex - 1];
                currentSemesterIndex--;
            }

            if (currentSemesterIndex == 0)
            {
                result = false;
            }

            return result;
        }

        public bool moveToNextSemester()
        {
            bool result = true;

            if (currentSemesterIndex < semesters.Count - 1)
            {
                CurrentSemester = semesters[currentSemesterIndex + 1];
                currentSemesterIndex++;
            }

            if (currentSemesterIndex == semesters.Count - 1)
            {
                result = false;
            }

            return result;
        }
    }
}
