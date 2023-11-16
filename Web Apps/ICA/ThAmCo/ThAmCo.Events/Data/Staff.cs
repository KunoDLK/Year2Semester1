using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double WeeklyHours { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }
    }
}
