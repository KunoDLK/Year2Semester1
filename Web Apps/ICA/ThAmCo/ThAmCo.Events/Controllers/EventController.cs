using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.DatabaseContexts;

namespace ThAmCo.Events.Controllers
{
    public class EventController : Controller
    {
        private EventDbContext _dbContext;

        public EventController(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Data.Event> events = new List<Data.Event>();

            events = _dbContext.Events.ToList();

            return View(events);
        }

        public IActionResult Create()
        {
            var newEvent = new Data.Event();

            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();

            return View("Edit", newEvent);
        }

        public IActionResult Edit(int id)
        {
            var retrivedEvent = _dbContext.Events.FirstOrDefault(e => e.Id == id);

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

            _dbContext.Events.Remove(deleteEvent);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Submit(Data.Event submittedEvent)
        {
            var databaseEvent = _dbContext.Events.FirstOrDefault(x => x.Id == submittedEvent.Id);

            if (databaseEvent == null)
            {
                _dbContext.Add(submittedEvent);
            }
            else
            {
                _dbContext.Entry(databaseEvent).CurrentValues.SetValues(submittedEvent);
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
