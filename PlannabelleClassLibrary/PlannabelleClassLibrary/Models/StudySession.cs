using System;
using System.Collections.Generic;
using System.Text;

namespace PlannabelleClassLibrary.Models
{
    public class StudySession
    {
        public int Id { get; set; }
        public Enrollment Enrollment { get; set; }
        public DateTime DateStudied { get; set; }
        public int MinutesStudied { get; set; }
    }
}
