using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Plannabelle_MVC.Data;
using PlannabelleClassLibrary.Models;

namespace Plannabelle_MVC.Controllers
{
    public class DashboardController : Controller
    {
        public ApplicationDbContext DbContext { get; set; } = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        private UserManager<AppUser> UserManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        // GET: DashboardController
        public ActionResult Index()
        {
            var currentUser = UserManager.GetUserAsync(HttpContext.User).Result;

            var userSemesters = (IEnumerable<UserSemester>) DbContext.UserSemesters.Where(x => x.User.UserName == currentUser.UserName);
            return View(userSemesters);
        }

        // GET: DashboardController/Details/5
        public ActionResult Details(int id)
        {
            // Redirect user to modules listing but show only modules that correspond with selected semester id
            RedirectToAction("Module", "Index", new { @id = id });
            return View();
        }

        //// GET: DashboardController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DashboardController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DashboardController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DashboardController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DashboardController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DashboardController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
