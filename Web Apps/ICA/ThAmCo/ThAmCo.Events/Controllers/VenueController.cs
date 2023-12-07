using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThAmCo.Events.Controllers
{
      public class VenueController : Controller
      {
            // GET: VenueController
            public ActionResult Index()
            {
                  return View();
            }

            // GET: VenueController/Details/5
            public ActionResult Details(int id)
            {
                  return View();
            }

            // GET: VenueController/Create
            public ActionResult Create()
            {
                  return View();
            }

            // POST: VenueController/Create
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

            // GET: VenueController/Edit/5
            public ActionResult Edit(int id)
            {
                  return View();
            }

            // POST: VenueController/Edit/5
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

            // GET: VenueController/Delete/5
            public ActionResult Delete(int id)
            {
                  return View();
            }

            // POST: VenueController/Delete/5
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
