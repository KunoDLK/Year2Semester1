using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.Data;
using ThAmCo.Events.DatabaseContexts;

namespace ThAmCo.Events.Controllers
{
    public class GuestsController : Controller
    {
        public EventDbContext DatabaseContext { get; set; }

        public GuestsController(EventDbContext context)
        {
            DatabaseContext = context;
        }

        // GET: GuestsController1
        public ActionResult Index()
        {
            List<Data.Guest> returnData;

            returnData = DatabaseContext.Guests.ToList();

            return View(returnData);
        }

        // GET: GuestsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestsController1/Create
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

        // GET: GuestsController1/Edit/5
        public ActionResult Edit(int id)
        {
            Guest editGuest;

            editGuest = DatabaseContext.Guests.FirstOrDefault(editGuest => editGuest.Id == id); 

            return View(editGuest);
        }

        // POST: GuestsController1/Edit/5
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

        // GET: GuestsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
