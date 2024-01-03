using ThAmCo.Events.Data;

namespace ThAmCo.Events.Models
{
    public class EventCreation
    {
        public EventCreation()
        {
            Event = new Event();
            EventTypes = new List<EventType>();
        }

        public Event Event { get; set; }

        public List<EventType> EventTypes { get; set; }

    }
}
