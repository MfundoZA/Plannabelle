using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;

namespace Plannabelle.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardViewModel DashboardViewModel { get; set; } = (DashboardViewModel) ViewModel.GetSingletonInstance();
        public PlannabelleDbContext DbContext { get; set; }
        public IHttpContextAccessor? HttpContextAccessor { get; set; }
        public Node<Semester>? CurrentlyVisibleSemester { get; set; }

        public DashboardController(IHttpContextAccessor httpContextAccessor, PlannabelleDbContext dbContext)
        {
            DbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;

            int userId = (int) (HttpContextAccessor.HttpContext?.Session.GetInt32("studentId"));

            var semesters = (from userSemester in DbContext.UserSemesters
                             where userSemester.StudentId == userId
                             select userSemester.Semester);

            foreach (var semester in semesters)
            {
                DashboardViewModel.Semesters?.addNode(semester);
            }

            // Ensures the default semester value does not overwrite
            // selection of other semesters
            if (CurrentlyVisibleSemester == null)
            {
                CurrentlyVisibleSemester = DashboardViewModel.Semesters?.Head;
            }
        }

        // GET: DashboardController
        ////public ActionResult Index()
        ////{
        ////    if (CurrentlyVisibleSemester != null)
        ////    {
        ////        ViewData["SemesterDuration"] = $"{CurrentlyVisibleSemester.Data?.StartDate.ToShortDateString()} - {CurrentlyVisibleSemester.Data?.EndDate.ToShortDateString()}";
        ////    }
        ////    else
        ////    {
        ////        ViewData["SemesterDuration"] = " - ";
        ////    }

        ////    return View(DashboardViewModel);
        ////}

        public ActionResult Index(int id)
        {
            var semesters = (from userSemester in DbContext.UserSemesters
                             where userSemester.StudentId == HttpContextAccessor.HttpContext.Session.GetInt32("studentId")
                             select userSemester.Semester).ToArray();

            CurrentlyVisibleSemester = new Node<Semester>(semesters.Where(x => x.Id == id).FirstOrDefault());

            ViewData["SemesterDuration"] = $"{CurrentlyVisibleSemester.Data?.StartDate.ToShortDateString()} - {CurrentlyVisibleSemester.Data?.EndDate.ToShortDateString()}";

            return View();
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

        public ActionResult NavigateToNextSemester()
        {
            if (CurrentlyVisibleSemester.Next != null)
            {
                CurrentlyVisibleSemester = CurrentlyVisibleSemester.Next;
                ViewData["SemesterDuration"] = $"{CurrentlyVisibleSemester.Data?.StartDate.ToShortDateString()} - {CurrentlyVisibleSemester.Data?.EndDate.ToShortDateString()}";
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult NavigateToPreviousSemester()
        {
            if (CurrentlyVisibleSemester.Previous != null)
            {
                CurrentlyVisibleSemester = CurrentlyVisibleSemester.Previous;
                ViewData["SemesterDuration"] = $"{CurrentlyVisibleSemester.Data?.StartDate.ToShortDateString()} - {CurrentlyVisibleSemester.Data?.EndDate.ToShortDateString()}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
