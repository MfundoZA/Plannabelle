using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Plannabelle_MVC.Data;
using PlannabelleClassLibrary.Models;

namespace Plannabelle_MVC.Controllers
{
    public class SemesterController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
        private UserManager<AppUser> _userManager;

        public SemesterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: SemesterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SemesterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SemesterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SemesterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Semester semester = new Semester();
                    semester.StartDate = DateTime.Parse(collection["StartDate"]);
                    semester.EndDate = DateTime.Parse(collection["EndDate"]);
                    dbContext.Add<Semester>(semester);
                    dbContext.SaveChanges();

                    UserSemester userSemester = new UserSemester();
                    userSemester.User = _userManager.GetUserAsync(HttpContext.User).Result;
                    userSemester.Semester = semester;
                    dbContext.Add<UserSemester>(userSemester);
                    dbContext.SaveChanges();

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SemesterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SemesterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: SemesterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SemesterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
