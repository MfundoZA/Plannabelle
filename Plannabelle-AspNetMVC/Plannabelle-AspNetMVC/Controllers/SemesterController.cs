using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannabelleClassLibrary.ViewModels;

namespace Plannabelle_AspNetMVC.Controllers
{
    public class SemesterController : Controller
    {
        public ViewAllSemestersViewModel ViewAllSemestersViewModel { get; set; }

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
                return RedirectToAction(nameof(Index));
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
