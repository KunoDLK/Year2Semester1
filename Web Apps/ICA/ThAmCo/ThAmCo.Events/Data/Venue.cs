using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Venues.Data
{
    public class Venue
    {
        public string Code { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Capacity { get; set; }
    }
}
