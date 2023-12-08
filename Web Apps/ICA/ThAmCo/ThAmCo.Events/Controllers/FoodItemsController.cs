using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThAmCo.Events.API;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers
{
    public class FoodItemsController : Controller
      {
            public APIController<FoodItem> APIController { get; set; }

            public FoodItemsController()
            {
                  APIController = new APIController<FoodItem>(BaseAPI.APIType.Catering, "FoodItem");
            }

            public async Task<IActionResult> Index()
            {
                  List<FoodItem> foodItems = await APIController.Get();

                  return View("index", foodItems);
            }

            public async Task<IActionResult> Delete(int foodItemId)
            {
                  await APIController.Delete(foodItemId);

                  new MenuFoodItemController().DeleteFoodItem(foodItemId);

                  return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Edit(int foodItemId)
            {
                  FoodItem item = await APIController.Get(foodItemId);

                  return View(item);
            }

            public async Task<IActionResult> SubmitItem(FoodItem foodItem)
            {
                  if (foodItem.Description != string.Empty && foodItem.Description != null)
                  {
                        if (foodItem.FoodItemId == 0)
                        {
                              await APIController.Post(foodItem);
                        }
                        else
                        {
                              await APIController.Put(foodItem);
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
