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
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"https://localhost:7173/api/FoodItems/{foodItemId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to delete");
                }
            }
            return await GetDataView();
        }

        private async Task<IActionResult> GetDataView()
        {
            List<FoodItem> items = new List<FoodItem>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7173/api/FoodItems");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<FoodItem>>(content);
                }
            }
            return View("~/Views/FoodItems/Index.cshtml", items);
        }
    }
}
