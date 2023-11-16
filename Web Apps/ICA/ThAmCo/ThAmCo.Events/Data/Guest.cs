using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Guest
    {
        public Guest() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }   

        [Required]
        public string ContactPhoneNumber { get; set; }

        [Required]
        public bool Banned { get; set; }

    }
}
