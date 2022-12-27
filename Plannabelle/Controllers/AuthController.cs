using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Plannabelle.Controllers
{
    public class AuthController : Controller
    {
        public AuthViewModel AuthViewModel { get; set; } = new AuthViewModel();
        public PlannabelleDbContext DbContext { get; set; } = new PlannabelleDbContext();
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public AuthController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
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
                var confirmationPassword = collection["confimationPassword"].ToString();

               if (String.Equals(password, confirmationPassword))
               {
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
    }
}
