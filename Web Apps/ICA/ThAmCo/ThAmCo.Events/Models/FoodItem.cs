using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
      public class FoodItem
      {
            public FoodItem() { }

            [Key]
            public int FoodItemId { get; set; }

            [Required, MaxLength(50)]
            public string Description { get; set; }

            [Required]
            public double UnitPrice { get; set; }
      }
}
