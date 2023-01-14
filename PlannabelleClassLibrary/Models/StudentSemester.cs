using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.Models
{
    public class StudentSemester
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;
    }
}
