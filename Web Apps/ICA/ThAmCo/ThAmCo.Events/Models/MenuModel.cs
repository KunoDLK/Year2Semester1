using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Models
{
    public class MenuModel
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public int FoodItemId { get; set; }
    }
}
