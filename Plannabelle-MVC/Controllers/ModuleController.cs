using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plannabelle_MVC.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;

namespace Plannabelle_MVC.Controllers
{
    public class ModuleController : Controller
    {
        public ModuleViewModel ModuleViewModel  { get; set; } = new ModuleViewModel();
        public ApplicationDbContext DbContext { get; set; } = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        private UserManager<AppUser> UserManager;

        public ModuleController(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        // GET: ModuleController
        public ActionResult Index(int id)
        {
            var _userModules = (from userModules in DbContext.UserModules
                                join userSemesters in DbContext.UserSemesters
                                on userModules.User.UserName equals userSemesters.User.UserName
                                where userSemesters.Id == id
                                select userModules);
            return View(_userModules);
        }

        // GET: ModuleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModuleController/Create
        public ActionResult Create()
        {
            return View(ModuleViewModel);
        }

        // POST: ModuleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var code = collection["Code"].ToString();
                var name = collection["Name"].ToString();
                var credits = Int32.Parse(collection["Credits"]);
                var currentUser = UserManager.GetUserAsync(HttpContext.User).Result;
                var classHoursPerWeek = Int32.Parse(collection["ClassHoursPerWeek"]);
                var selfStudyHoursPerWeek = Int32.Parse(ModuleViewModel.calculateSelfStudyHours(credits, 22, classHoursPerWeek).ToString());
                var selfStudyHoursRemainingForWeek = Int32.Parse(collection["SelfStudyHoursRemainingForWeek"]);

                Module module = new Module(code, name, credits);
                DbContext.Add<Module>(module);

                UserModule userModule = new UserModule(currentUser, module, classHoursPerWeek, selfStudyHoursPerWeek, selfStudyHoursRemainingForWeek);
                DbContext.Add<UserModule>(userModule);

                DbContext.SaveChanges();
                return RedirectToAction("Dashboard", "Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ModuleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModuleController/Edit/5
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

        // GET: ModuleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModuleController/Delete/5
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
