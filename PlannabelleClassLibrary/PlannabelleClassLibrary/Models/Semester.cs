using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace PlannabelleClassLibrary.Models
{
    /*  Stack Overflow. 2015. using of INotifyPropertyChanged,
     *  17 November 2015. [Online]. Available at:
     *  https://stackoverflow.com/questions/33641182/using-of-inotifypropertychanged
     *  [Accessed 14 October 2022].
     */
    public class Semester : INotifyPropertyChanged
    {
        // Properties
        public int Id { get; set; }
        private DateTime startDate;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate { get; set; }

        // Constructor
        public Semester(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}