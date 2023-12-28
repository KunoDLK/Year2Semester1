using System.ComponentModel.DataAnnotations;
using Humanizer;

namespace ThAmCo.Events.Data
{
    public class Event
    {
        public Event() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string EventTypeId { get; set; } = "";

        public int? foodBookingID { get; set; }

    }
}
