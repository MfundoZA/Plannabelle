using PlannabelleClassLibrary.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PlannabelleClassLibrary.ViewModels
{
    /*
     * The BaseViewModel class is responible for holding values that are need in muliple
     * parts of the app. To enable this every over other viewmodel inherits this class
     * and therefore get easily access these properties
     */
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<Semester> semesters { get; set; }
        public static Semester currentSemester;
        public static User User { get; set; }
        public static int currentSemesterIndex { get; set; }

        public Semester CurrentSemester
        {
            get
            {
                return currentSemester;
            }

            set
            {
                currentSemester = value;
                OnPropertyChanged(nameof(currentSemester));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}