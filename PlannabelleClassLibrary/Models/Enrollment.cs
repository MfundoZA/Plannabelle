using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int StudentSemesterId { get; set; }
        public StudentSemester StudentSemester { get; set; } = null!;

        public int StudentModuleId { get; set; }
        public StudentModule StudentModule { get; set; } = null!;
    }
}
