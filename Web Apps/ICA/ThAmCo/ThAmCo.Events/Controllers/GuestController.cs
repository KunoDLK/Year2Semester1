using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.Data;
using ThAmCo.Events.DatabaseContexts;

namespace ThAmCo.Events.Controllers
{
    public class GuestController : Controller
    {
        public EventDbContext DatabaseContext { get; set; }

        public GuestController(EventDbContext context)
        {
            DatabaseContext = context;
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
                var DBGuest = DatabaseContext.Guests.First(x=> x.Id == id);
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
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
