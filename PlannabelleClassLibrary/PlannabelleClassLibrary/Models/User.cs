using System;
using System.Collections.Generic;
using System.Text;

namespace PlannabelleClassLibrary.Models
{
    public class User
    {
        // Properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }

        // Constructors
        public User()
        {
        }

        public User(string username, string hashedPassword)
        {
            Username = username;
            HashedPassword = hashedPassword;
        }

        public User(int id, string email, string username, string hashedPassword)
        {
            Id = id;
            Email = email;
            Username = username;
            HashedPassword = hashedPassword;
        }
    }
}
