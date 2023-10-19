using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
      public class MenuFoodItems
      {
            public MenuFoodItems() { }

            [Key]
            public int Id { get; set; }

            [Required]
            public int MenuId { get; set; }

            [Required]
            public int FoodItemId { get; set; }
      }
}
