using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Event
    {
        public Event() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public int EventTypeId { get; set; }

    }
}
