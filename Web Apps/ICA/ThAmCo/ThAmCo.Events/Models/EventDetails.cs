using ThAmCo.Events.Data;

namespace ThAmCo.Events.Models
{
    public class EventDetails
    {
        public Event Event { get; set; }

        public List<EventType> EventTypes { get; set; }

        public List<Guest> Guests { get; set; }

        public Menu Menu { get; set; }

        public FoodBooking FoodBooking { get; set; }

        public Dictionary<int, string> Menus { get; set; }
    }
}
