using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.API;
using ThAmCo.Events.Data;
using ThAmCo.Events.DatabaseContexts;
using ThAmCo.Events.Migrations;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class EventController : Controller
    {
        private APIController<EventType> EventTypeAPI { get; set; }

        private APIController<Guest> GuestAPI { get; set; }

        private APIController<Menu> MenuAPI { get; set; }

        private EventDbContext DbContext { get; set; }

        public EventController(EventDbContext dbContext)
        {
            DbContext = dbContext;
            EventTypeAPI = new APIController<EventType>(BaseAPI.APIType.Venues, "eventtypes");
            GuestAPI = new APIController<Guest>(BaseAPI.APIType.Venues, "guest");
            MenuAPI = new APIController<Menu>(BaseAPI.APIType.Catering, "menus");
        }

        public IActionResult Index()
        {
            List<Data.Event> events = new List<Data.Event>();

            events = DbContext.Events.ToList();

            return View(events);
        }

        public IActionResult Create()
        {
            var newEvent = new Data.Event();

            newEvent.StartTime = DateTime.Now.Date;
            newEvent.EndTime = DateTime.Now.Date;

            DbContext.Events.Add(newEvent);
            DbContext.SaveChanges();

            return View("Edit", newEvent);
        }

        public IActionResult Edit(int id)
        {
            var retrivedEvent = DbContext.Events.FirstOrDefault(e => e.Id == id);

            if (retrivedEvent == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(retrivedEvent);
            }
        }

        public IActionResult Delete(int id)
        {
            Data.Event deleteEvent = new Data.Event { Id = id };

            DbContext.Events.Remove(deleteEvent);

            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Submit(Data.Event submittedEvent)
        {
            var databaseEvent = DbContext.Events.FirstOrDefault(x => x.Id == submittedEvent.Id);

            if (databaseEvent == null)
            {
                DbContext.Add(submittedEvent);
            }
            else
            {
                DbContext.Entry(databaseEvent).CurrentValues.SetValues(submittedEvent);
            }

            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            EventDetails eventDetails = new EventDetails
            {
                Event = DbContext.Events.FirstOrDefault(x => x.Id == id),
                EventTypes = await EventTypeAPI.Get(),
                Menus = (await MenuAPI.Get()).ToDictionary(menu => menu.MenuId, menu => menu.MenuName)
            };


            return View(eventDetails);
        }
    }
}
