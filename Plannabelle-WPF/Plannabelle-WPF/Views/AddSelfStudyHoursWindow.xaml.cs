using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Plannabelle_WPF.Views
{
    /// <summary>
    /// Interaction logic for AddSelfStudyHoursWindow.xaml
    /// </summary>
    public partial class AddSelfStudyHoursWindow : Window
    {
        public AddSelfStudyHoursViewModel AddSelfStudyHoursViewModel { get; set; }

        public AddSelfStudyHoursWindow()
        {
            InitializeComponent();

            AddSelfStudyHoursViewModel = new AddSelfStudyHoursViewModel();
            DataContext = AddSelfStudyHoursViewModel;
        }

        private void btnAddStudyHours_Click(object sender, RoutedEventArgs e)
        {
            var moduleId = Int32.Parse(cmbModules.SelectedValue.ToString());
            var hoursStudied = Int32.Parse(txtHoursStudied.Text);

            AddSelfStudyHoursViewModel.UpdateSelfStudyHours(moduleId, hoursStudied);

        }
    }
}
