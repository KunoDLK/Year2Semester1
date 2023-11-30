using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Controllers
{
    public class MenusController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var returnList = await API.MenuController.Get();

            return View(returnList);
        }

        public async Task<IActionResult> Create()
        {
            List<FoodItem> items = await API.FoodItemController.Get();

            ViewData["FoodItems"] = items.Select(item => new Dictionary<int, string> { { item.FoodItemId, item.Description } });

            return View();
        }
    }
}
