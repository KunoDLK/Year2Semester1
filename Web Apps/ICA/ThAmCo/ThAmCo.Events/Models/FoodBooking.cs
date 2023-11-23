using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
      public class FoodBooking
      {
            public FoodBooking() { }

            [Key]
            public int Id { get; set; }

            [Required]
            public int ClientId { get; set; }

            [Required]
            public int NumberOfGuests { get; set; }

            [Required]
            public int MenuId { get; set; }
      }
}
