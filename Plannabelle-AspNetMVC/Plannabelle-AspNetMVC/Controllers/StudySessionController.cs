using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Plannabelle_AspNetMVC.Controllers
{
    public class StudySessionController : Controller
    {
        // GET: StudySessionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudySessionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudySessionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudySessionController/Create
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

        // GET: StudySessionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudySessionController/Edit/5
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

        // GET: StudySessionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudySessionController/Delete/5
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
