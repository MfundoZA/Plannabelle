using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ValidateAntiForgeryTokenAttribute = Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute;

namespace Plannabelle.Controllers
{
    public class ModuleController : Controller
    {
        public ModuleViewModel ModuleViewModel { get; set; } = new ModuleViewModel();
        public IHttpContextAccessor? HttpContextAccessor { get; set; }
        public PlannabelleDbContext DbContext { get; set; }

        public ModuleController(IHttpContextAccessor httpContextAccessor, PlannabelleDbContext dbContext)
        {
            HttpContextAccessor = httpContextAccessor;
            DbContext = dbContext;
        }

        // GET: ModuleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ModuleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModuleController/Create
        public ActionResult Create()
        {
            var semesters = (from userSemesters in DbContext.UserSemesters
                             where userSemesters.StudentId == HttpContextAccessor.HttpContext.Session.GetInt32("studentId")
                             select userSemesters.Semester).ToList();

            ModuleViewModel.Semesters = semesters;

            return View(ModuleViewModel);
        }

        // POST: ModuleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newModule = new Module();
                newModule.Code = collection["Code"].ToString();
                newModule.Name = collection["Name"].ToString();
                newModule.Credits = Int32.Parse(collection["Credits"].ToString());
                newModule.ClassHoursPerWeek = Int32.Parse(collection["ClassHoursPerWeek"].ToString());
                
                var newEnrollment = new Enrollment();
                newEnrollment.Student = DbContext.Students.Where(x => x.Id == HttpContextAccessor.HttpContext.Session.GetInt32("studentId")).First();
                newEnrollment.Semester = DbContext.UserSemesters.Where(x => x.Semester.Id == Int32.Parse(collection["SemesterId"].ToString())).Select(x => x.Semester).First();
                newEnrollment.Module = newModule;
                newEnrollment.SelfStudyHoursPerWeek = Double.Parse(collection["SelfStudyHoursPerWeek"].ToString());
                newEnrollment.SelfStudyHoursRemaining = Double.Parse(collection["SelfStudyHoursRemaining"].ToString());

                DbContext.Add(newEnrollment);
                DbContext.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
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
