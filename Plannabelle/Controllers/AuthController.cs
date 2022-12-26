using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.ViewModels;

namespace Plannabelle.Controllers
{
    public class AuthController : Controller
    {
        public AuthViewModel AuthViewModel { get; set; } = new AuthViewModel();
        public PlannabelleDbContext DbContext { get; set; } = new PlannabelleDbContext();

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
                var username = collection["username"];
                var email = collection["email"];
                var password = collection["password"];
                var confirmationPassword = collection["confimationpassword"];

               

                return RedirectToAction(nameof(Index));
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
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
