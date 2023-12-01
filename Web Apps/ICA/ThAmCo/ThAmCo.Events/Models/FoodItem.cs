using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
      public class FoodItem
      {
            public FoodItem() { }

            public int FoodItemId { get; set; }

            public string Description { get; set; }

            public double UnitPrice { get; set; }

      }
}
