using PlannabelleClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlannabelleClassLibrary.ViewModels
{
    public class ModuleViewModel
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Credits { get; set; }
        public double ClassHoursPerWeek  { get; set; }

        [DisplayName("Semester")]
        public int SemesterId { get; set; }

        public List<Semester> Semesters { get; set; } = null!;

        public double SelfStudyHoursPerWeek { get; set; }
        public double SelfStudyHoursRemaining { get; set; }
    }
}
