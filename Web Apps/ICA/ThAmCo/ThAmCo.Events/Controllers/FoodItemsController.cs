using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThAmCo.Catering.Data;

namespace ThAmCo.Events.Controllers
{
    public class FoodItemsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await GetDataView();
        }

        public async Task<IActionResult> Delete(int foodItemId)
        {
            Data.FoodItemApiController.DeleteItem(foodItemId);

            return await GetDataView();
        }

        private async Task<IActionResult> GetDataView()
        {
            List<FoodItem> foodItems = await Data.FoodItemApiController.GetAllItems();

            return View("~/Views/FoodItems/Index.cshtml", foodItems);
        }

        public async Task<IActionResult> Edit(int foodItemId)
        {
            return View();
        }
    }
}
