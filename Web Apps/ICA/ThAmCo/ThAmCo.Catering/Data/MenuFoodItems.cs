﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo.Catering.Data
{
    public class MenuFoodItems
    {
        public MenuFoodItems() { }

        [ForeignKey(nameof(Menu))]
        public int MenuId { get; set; }

        [ForeignKey(nameof(FoodItem))]
        public int FoodItemId { get; set; }
    }
}
