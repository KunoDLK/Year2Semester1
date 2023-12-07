using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThAmCo.Events.Controllers
{
      public class VenueAvalibilityController : Controller
      {
            // GET: EventAvalibilityController
            public ActionResult Index()
            {
                  return View();
            }

            // GET: EventAvalibilityController/Details/5
            public ActionResult Details(int id)
            {
                  return View();
            }

            // GET: EventAvalibilityController/Create
            public ActionResult Create()
            {
                  return View();
            }

            // POST: EventAvalibilityController/Create
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

            // GET: EventAvalibilityController/Edit/5
            public ActionResult Edit(int id)
            {
                  return View();
            }

            // POST: EventAvalibilityController/Edit/5
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

            // GET: EventAvalibilityController/Delete/5
            public ActionResult Delete(int id)
            {
                  return View();
            }

            // POST: EventAvalibilityController/Delete/5
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
