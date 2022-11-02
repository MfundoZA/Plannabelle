using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.ViewModels
{
    public class NewUserViewModel
    {
        public UserDataService UserDataService { get; set; } = new UserDataService(PlannabelleContextDbFactory.GetDbContext());

        public bool WriteUserToDatabase(User newUser)
        {
            UserDataService.Insert(newUser);

            return true;
        }
    }
}
