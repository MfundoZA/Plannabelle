using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.Models
{
    public class Enrollment
    {
        // Properties
        public int Id { get; set; }
        public UserModule Module { get; set; }
        public UserSemester Semester { get; set; }

        // Constructors
        public Enrollment()
        {

        }
    }
}
