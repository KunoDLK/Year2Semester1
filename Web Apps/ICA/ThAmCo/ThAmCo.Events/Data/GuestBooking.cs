using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo.Events.Data
{
    public class GuestBooking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Guest))]
        public int EventID { get; set; }

        [Required]
        [ForeignKey(nameof(Guest))]
        public int GuestID { get; set; }
    }
}
