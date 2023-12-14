using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.API;
using ThAmCo.Events.DatabaseContexts;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class EventController : Controller
    {
        private APIController<EventType> APIController { get; set; }
        private EventDbContext DbContext { get; set; }

        public EventController(EventDbContext dbContext)
        {
            DbContext = dbContext;
            APIController = new APIController<EventType>(BaseAPI.APIType.Venues, "EventTypes");
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

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
