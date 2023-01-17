using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.ViewModels
{
    public class ModuleViewModel
    {
        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public int Credits { get; set; }
        public double ClassHoursPerWeek  { get; set; }

        [DisplayName("Semester")]
        public int SemesterId { get; set; }

        public double SelfStudyHoursPerWeek { get; set; }
        public double SelfStudyHoursRemaining { get; set; }
    }
}
