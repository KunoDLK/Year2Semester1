using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class EventTypeController : Controller
      {
            // GET: EventTypeController_
            public ActionResult Index()
            {
                  List<EventType> typeList = new List<EventType>();

                  return View(typeList);
            }

            // GET: EventTypeController_/Details/5
            public ActionResult Details(int id)
            {
                  return View();
            }

            // GET: EventTypeController_/Create
            public ActionResult Create()
            {
                  return View();
            }

            // POST: EventTypeController_/Create
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

            // GET: EventTypeController_/Edit/5
            public ActionResult Edit(int id)
            {
                  return View();
            }

            // POST: EventTypeController_/Edit/5
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

            // GET: EventTypeController_/Delete/5
            public ActionResult Delete(int id)
            {
                  return View();
            }

            // POST: EventTypeController_/Delete/5
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
