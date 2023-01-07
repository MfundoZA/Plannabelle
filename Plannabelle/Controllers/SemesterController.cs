using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;

namespace Plannabelle.Controllers
{
    public class SemesterController : Controller
    {
        public SemesterViewModel SemesterViewModel { get; set; } = new SemesterViewModel();
        public IHttpContextAccessor? HttpContextAccessor { get; set; }
        public PlannabelleDbContext DbContext { get; set; }

        public SemesterController(IHttpContextAccessor httpContextAccessor, PlannabelleDbContext dbContext)
        {
            HttpContextAccessor = httpContextAccessor;
            DbContext = dbContext;
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
                var newSemester = new Semester();
                newSemester.StartDate = DateTime.Parse(collection["StartDate"].ToString());
                newSemester.EndDate = DateTime.Parse(collection["EndDate"].ToString());

                var newStudentSemester = new StudentSemester();
                newStudentSemester.Student = (Student) DbContext.Students.Where(x => x.Id == HttpContextAccessor.HttpContext.Session.GetInt32("studentId"));
                newStudentSemester.Semester = newSemester;

                DbContext.Add(newStudentSemester);
                DbContext.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
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
