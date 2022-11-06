using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Plannabelle_AspNetMVC.Controllers
{
    public class ModuleController : Controller
    {
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
            return View();
        }

        // POST: ModuleController/Create
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
