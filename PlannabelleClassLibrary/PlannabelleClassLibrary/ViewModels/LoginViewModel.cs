using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public UserDataService UserDataService { get; set; }

        public LoginViewModel()
        {
            UserDataService = new UserDataService(PlannabelleContextDbFactory.GetDbContext());
        }
        public string HashPassword(string password, string salt = "nf8n43nsd9s")
        {
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }

        public List<User> ReadUsersfromDatabase()
        {
            return UserDataService.getAll();
        }

        public bool WriteUserToDatabase(User user)
        {
            UserDataService.Insert(user);

            return true;
        }
    }
}
