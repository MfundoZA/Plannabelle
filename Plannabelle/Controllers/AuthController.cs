using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Plannabelle.Controllers
{
    public class AuthController : Controller
    {
        public AuthViewModel AuthViewModel { get; set; } = new AuthViewModel();
        public PlannabelleDbContext DbContext { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public AuthController(IHttpContextAccessor httpContextAccessor, PlannabelleDbContext dbContext)
        {
            HttpContextAccessor = httpContextAccessor;
            DbContext = dbContext;
        }

        // GET: AuthController/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: AuthController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
        {
            try
            {
                var username = collection["username"].ToString();
                var email = collection["email"].ToString();
                var password = collection["password"].ToString();
                var confirmationPassword = collection["confirmationPassword"].ToString();

               if (String.Equals(password, confirmationPassword))
               {
                    password = HashString(password);
                    var newStudent = new Student(username, email, password);

                    DbContext.Add<Student>(newStudent);
                    DbContext.SaveChanges();
               }

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: AuthController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
        {
            ViewBag.Message = "";

            try
            {
                var email = collection["email"].ToString();
                var password = collection["password"].ToString();

                if (DbContext.Students.Where<Student>(x => String.Equals(x.Email, email) && String.Equals(x.Password , password)).Any())
                {
                    var student = DbContext.Students.Where<Student>(x => String.Equals(x.Email, email) && String.Equals(x.Password, password)).First();

                    HttpContextAccessor.HttpContext?.Session.SetInt32("userId", student.Id);
                    HttpContextAccessor.HttpContext?.Session.SetString("email", student.Email);
                }
                else
                {
                    ViewBag.Message = "Incorrect email or password please try again";
                }

                
            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        static string HashString(string text, string salt = "nf8n43nsd9s")
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            // Uses SHA256 to create the hash
            using (var sha = SHA256.Create())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
    }
}
