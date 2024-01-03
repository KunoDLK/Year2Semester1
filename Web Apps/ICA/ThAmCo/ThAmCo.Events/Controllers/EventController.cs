using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        private APIController<FoodBooking> FoodBookingAPI { get; set; }

        private EventDbContext DbContext { get; set; }

        /// <summary>
        /// Constructor of event controller
        /// </summary>
        /// <param name="dbContext">database context</param>
        public EventController(EventDbContext dbContext)
        {
            DbContext = dbContext;
            EventTypeAPI = new APIController<EventType>(BaseAPI.APIType.Venues, "eventtypes");
            GuestAPI = new APIController<Guest>(BaseAPI.APIType.Venues, "guest");
            MenuAPI = new APIController<Menu>(BaseAPI.APIType.Catering, "menus");
            FoodBookingAPI = new APIController<FoodBooking>(BaseAPI.APIType.Catering, "foodbookings");
        }

/// <summary>
/// returns list of Event Types
/// </summary>
/// <returns></returns>
        public async Task<IActionResult> Index()
        {
            ViewBag.EventTypes = await EventTypeAPI.Get();

            List<Event> events = new List<Event>();
            events = DbContext.Events.ToList();

            return View(events);
        }

        /// <summary>
        /// Creates a new Event
        /// </summary>
        /// <returns> view to edit the new event</returns>
        public async Task<IActionResult> Create()
        {
            var newEvent = new Models.EventCreation();

            newEvent.Event.StartTime = DateTime.Now.Date;
            newEvent.Event.EndTime = DateTime.Now.Date;

            DbContext.Events.Add(newEvent.Event);
            DbContext.SaveChanges();

            newEvent.EventTypes = await EventTypeAPI.Get();

            return View("Edit", newEvent);
        }

        /// <summary>
        /// Edits an events base properties 
        /// </summary>
        /// <param name="id"> event id</param>
        /// <returns>view to edit an event </returns>
        public async Task<IActionResult> Edit(int id)
        {
            var retrivedEvent = DbContext.Events.FirstOrDefault(e => e.Id == id);
            if (retrivedEvent == null)
                return RedirectToAction("Index");

            EventCreation editEvent = new()
            {
                Event = retrivedEvent,
                EventTypes = await EventTypeAPI.Get()
            };

            return View(retrivedEvent);
        }

        /// <summary>
        /// Deletes an event
        /// </summary>
        /// <param name="id">id of event to delete</param>
        /// <returns>redirect to index</returns>
        public IActionResult Delete(int id)
        {
            Data.Event deleteEvent = new Data.Event { Id = id };

            DbContext.Events.Remove(deleteEvent);

            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Submitted event with modification 
        /// </summary>
        /// <param name="submittedEvent">event to update</param>
        /// <returns>redirect to index</returns>
        public IActionResult Submit(Models.EventCreation submittedEvent)
        {
            var databaseEvent = DbContext.Events.FirstOrDefault(x => x.Id == submittedEvent.Event.Id);

            if (databaseEvent == null)
            {
                DbContext.Add(submittedEvent.Event);
            }
            else
            {
                DbContext.Entry(databaseEvent).CurrentValues.SetValues(submittedEvent.Event);
            }

            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets details of a event 
        /// </summary>
        /// <param name="id">id of event</param>
        /// <returns>details view</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            EventDetails eventDetails = new EventDetails
            {
                Event = DbContext.Events.FirstOrDefault(x => x.Id == id),
                EventTypes = await EventTypeAPI.Get(),
                Menus = (await MenuAPI.Get()).ToDictionary(menu => menu.MenuId, menu => menu.MenuName),
            };

            List<int> guests = DbContext.GuestBookings.Where(x => x.EventID == id).Select(x => x.GuestID).ToList();

            eventDetails.Guests = DbContext.Guests.Where(x => guests.Contains(x.Id)).ToList();

            if (eventDetails.Event.foodBookingID != null)
            {
                eventDetails.FoodBooking = await FoodBookingAPI.Get((int)eventDetails.Event.foodBookingID);
                eventDetails.Menu = await MenuAPI.Get(eventDetails.FoodBooking.MenuId);
            }

            return View("Details", eventDetails);
        }

        /// <summary>
        /// Sets menu for an event
        /// </summary>
        /// <param name="menuId">id of menu</param>
        /// <param name="eventId">id of event</param>
        /// <param name="foodBookingId">optional foodbooking id if we are editing a event food order </param>
        /// <returns> modified details view </returns>
        public async Task<IActionResult> SetMenu(int? menuId, int eventId, int? foodBookingId)
        {
            if (menuId == null || eventId == null)
                return RedirectToAction("Index");


            if (foodBookingId == null)
            {
                var foodOrder = new FoodBooking()
                {
                    MenuId = (int)menuId,
                    NumberOfGuests = DbContext.GuestBookings.Count(x => x.EventID == eventId),
                };

                foodBookingId = await FoodBookingAPI.Post(foodOrder);

                var databaseEvent = DbContext.Events.FirstOrDefault(x => x.Id == eventId);

                databaseEvent.foodBookingID = foodBookingId;

                DbContext.SaveChanges();
            }
            else
            {
                var booking = await FoodBookingAPI.Get((int)foodBookingId);

                booking.MenuId = (int)menuId;

                await FoodBookingAPI.Put(booking);
            }

            return RedirectToAction("Details", new { id = eventId });
        }

        /// <summary>
        /// Cancels food order
        /// </summary>
        /// <param name="eventId"> event to remove food order </param>
        /// <param name="foodBookingId"> id of food booking </param>
        /// <returns></returns>
        public async Task<IActionResult> CancelFood(int eventId, int foodBookingId)
        {
            await FoodBookingAPI.Delete(foodBookingId);

            var databaseEvent = DbContext.Events.FirstOrDefault(x => x.Id == eventId);

            databaseEvent.foodBookingID = null;

            DbContext.SaveChanges();

            return RedirectToAction("Details", new { id = eventId });
        }

        /// <summary>
        /// adds a guest to a event 
        /// </summary>
        /// <param name="eventId"> id of event</param>
        /// <param name="name"> name of guest</param>
        /// <param name="phonenumber">phone number of guest </param>
        /// <returns></returns>
        public async Task<IActionResult> AddGuest(int eventId, string name, string phonenumber)
        {
            //try to find guest
            var databaseGuest = DbContext.Guests.FirstOrDefault(x => x.Name == name && x.ContactPhoneNumber == phonenumber);

            int guestId;
            if (databaseGuest != null)
            {
                guestId = databaseGuest.Id;
            }
            else
            {
                var newGuest = new Guest() { Name = name, ContactPhoneNumber = phonenumber };

                DbContext.Guests.Add(newGuest);
                DbContext.SaveChanges();

                guestId = newGuest.Id;
            }

            if (!DbContext.GuestBookings.Any(x => x.GuestID == guestId && x.EventID == eventId))
            {
                DbContext.GuestBookings.Add(new GuestBooking() { EventID = eventId, GuestID = guestId });
                DbContext.SaveChanges();
            }

            return RedirectToAction("Details", new { id = eventId });
        }

        /// <summary>
        /// Removes a guest from an event
        /// </summary>
        /// <param name="id"> id of guest </param>
        /// <param name="eventId"> event to remove guest from </param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveGuest(int id, int eventId)
        {
            var guestBooking = DbContext.GuestBookings.First(x => x.EventID == eventId && x.GuestID == id);
            DbContext.GuestBookings.Remove(guestBooking);
            DbContext.SaveChanges();

            return RedirectToAction("Details", new { id = eventId });
        }

        /// <summary>
        /// Changes food order quantity
        /// </summary>
        /// <param name="eventId"> event to effect </param>
        /// <param name="foodBookingId"> id of food booking </param>
        /// <param name="orderQuantity"> quantity to set</param>
        /// <returns></returns>
        public async Task<IActionResult> ChangeOrderQuantity(int eventId, int foodBookingId, int orderQuantity)
        {
            var foodBooking = await FoodBookingAPI.Get(foodBookingId);

            foodBooking.NumberOfGuests = orderQuantity;

            await FoodBookingAPI.Put(foodBooking);

            return RedirectToAction("Details", new { id = eventId });
        }
    }
}
