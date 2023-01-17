using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;

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
            var semesters = (from studentSemester in DbContext.StudentSemesters
                             join semester in DbContext.Semesters
                             on studentSemester.StudentId equals HttpContextAccessor.HttpContext.Session.GetInt32("studentId")
                             select studentSemester.Semester).ToList();

            ViewData["Semesters"] = semesters;

            return View();
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

                var newStudentModule = new StudentModule();
                newStudentModule.Student = DbContext.Students.Where(x => x.Id == HttpContextAccessor.HttpContext.Session.GetInt32("studentId")).First();
                newStudentModule.Module = newModule;
                newStudentModule.SelfStudyHoursPerWeek = Double.Parse(collection["SelfStudyHoursPerWeek"].ToString());
                newStudentModule.SelfStudyHoursRemaining = Double.Parse(collection["SelfStudyHoursRemaining"].ToString());

                var newEnrollment = new Enrollment();
                newEnrollment.Student = newStudentModule.Student;
                newEnrollment.StudentSemester = DbContext.StudentSemesters.Where(x => x.Id == Int32.Parse(collection["Semester"].ToString())).First();
                newEnrollment.StudentModule = newStudentModule;

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
