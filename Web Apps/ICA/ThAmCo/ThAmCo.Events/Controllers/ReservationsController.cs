using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.API;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class ReservationsController : Controller
    {
        private APIController<Reservation> APIController { get; set; }
        public ReservationsController()
        {
            APIController = new APIController<Reservation>(BaseAPI.APIType.Venues, "reservations");
        }

        // GET: VenueController
        public async Task<ActionResult> Index()
        {
            var reservation = await APIController.Get();

            return View(reservation);
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
