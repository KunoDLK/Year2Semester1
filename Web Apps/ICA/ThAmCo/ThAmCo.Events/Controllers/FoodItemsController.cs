using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Controllers
{
      public class FoodItemsController : Controller
      {
            public async Task<IActionResult> Index()
            {
                  List<FoodItem> foodItems = await API.FoodItemController.Get();

                  return View("index", foodItems);
            }

            public async Task<IActionResult> Delete(int foodItemId)
            {
                  await API.FoodItemController.Delete(foodItemId);

                  API.MenuFoodItemController.DeleteFoodItem(foodItemId);

                  return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Edit(int foodItemId)
            {
                  FoodItem item = await API.FoodItemController.Get(foodItemId);

                  return View(item);
            }

            public async Task<IActionResult> SubmitItem(FoodItem foodItem)
            {
                  if (foodItem.Description != string.Empty && foodItem.Description != null)
                  {
                        if (foodItem.FoodItemId == 0)
                        {
                              await API.FoodItemController.Post(foodItem);
                        }
                        else
                        {
                              await API.FoodItemController.Put(foodItem);
                        }
                  }

                  return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Create()
            {
                  return View("Edit");
            }
      }
}
