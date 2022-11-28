using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.Models
{
    public class UserSemester
    {
        public int Id { get; set; }
        public  AppUser User { get; set; }
        public Semester Semester { get; set; }
    }
}
