using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.Models
{
    public class UserModule
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public Module Module { get; set; }
        public int ClassHoursPerWeek { get; set; }
        public int SelfStudyHoursPerWeek { get; set; }
        public double SelfStudyHoursRemainingForWeek { get; set; }

        public UserModule(AppUser user, Module module, int classHoursPerWeek, int selfStudyHoursPerWeek, double selfStudyHoursRemainingForWeek)
        {
            User = user;
            Module = module;
            ClassHoursPerWeek = classHoursPerWeek;
            SelfStudyHoursPerWeek = selfStudyHoursPerWeek;
            SelfStudyHoursRemainingForWeek = selfStudyHoursRemainingForWeek;
        }

        public UserModule()
        {

        }
    }
}
