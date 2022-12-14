using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;

namespace Plannabelle.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardViewModel DashboardViewModel { get; set; } = new DashboardViewModel();
        public PlannabelleDbContext DbContext { get; set; }
        public IHttpContextAccessor? HttpContextAccessor { get; set; }
        public Node<Semester>? CurrentlyVisibleSemester { get; set; }

        public DashboardController(IHttpContextAccessor httpContextAccessor, PlannabelleDbContext dbContext)
        {
            DbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;

            int userId = (int) (HttpContextAccessor.HttpContext?.Session.GetInt32("studentId"));

            var semesters = (from studentSemester in DbContext.StudentSemesters
                             where studentSemester.Student.Id == userId
                             select studentSemester.Semester);

            foreach (var semester in semesters)
            {
                DashboardViewModel.Semesters?.addNode(semester);
            }

            CurrentlyVisibleSemester =  DashboardViewModel.Semesters?.Head;
        }

        // GET: DashboardController
        public ActionResult Index()
        {
            if (CurrentlyVisibleSemester != null)
            {
                ViewData["SemesterDuration"] = $"{CurrentlyVisibleSemester.Data?.StartDate.ToShortDateString()} - {CurrentlyVisibleSemester.Data?.EndDate.ToShortDateString()}";
            }
            else
            {
                ViewData["SemesterDuration"] = " - ";
            }

            return View(DashboardViewModel);
        }

        // GET: DashboardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DashboardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardController/Edit/5
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

        // GET: DashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardController/Delete/5
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
