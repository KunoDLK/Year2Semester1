using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.API;
using ThAmCo.Events.Data;
using ThAmCo.Events.DatabaseContexts;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class GuestController : Controller
    {
        public EventDbContext DatabaseContext { get; set; }

        private APIController<EventType> EventTypeAPI { get; set; }

        public GuestController(EventDbContext context)
        {
            DatabaseContext = context;
            EventTypeAPI = new APIController<EventType>(BaseAPI.APIType.Venues, "eventtypes");
        }

        // GET: GuestsController
        public ActionResult Index()
        {
            List<Guest> returnData = new List<Guest>();

            returnData = DatabaseContext.Guests.ToList();

            return View(returnData);
        }

        // GET: GuestsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guest guest)
        {
            try
            {
                DatabaseContext.Guests.Add(guest);
                DatabaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GuestsController/Edit/5
        public ActionResult Edit(int id)
        {
            Guest editGuest;

            editGuest = DatabaseContext.Guests.FirstOrDefault(editGuest => editGuest.Id == id);

            return View(editGuest);
        }

        // POST: GuestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Guest updatedGuest)
        {
            try
            {
                var DBGuest = DatabaseContext.Guests.First(x => x.Id == id);
                DBGuest.Name = updatedGuest.Name;
                DBGuest.ContactPhoneNumber = updatedGuest.ContactPhoneNumber;
                DBGuest.Banned = updatedGuest.Banned;
                DatabaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GuestsController/Delete/5
        public async Task<ActionResult> Details(int id)
        {
            ViewBag.EventTypes = await EventTypeAPI.Get();

            var events = DatabaseContext.GuestBookings.Where(x => x.GuestID == id).Select(x => x.EventID).ToList();

            List<Event> returnlist = DatabaseContext.Events.Where(x => events.Contains(x.Id)).ToList();

            return View(returnlist);
        }
    }
}
