using System.Text;
using Newtonsoft.Json;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.API
{
      public static class MenuFoodItemController
      {
            public async static void DeleteFoodItem(int foodId)
            {
                  var items = await Get();

                  var itemsToDelete = items.Where(x => x.FoodItemId == foodId).ToList();

                  foreach (var item in itemsToDelete)
                  {
                        Delete(item);
                  }
            }

            public async static Task<List<MenuFoodItems>> Get()
            {

                  List<MenuFoodItems> items = new List<MenuFoodItems>();
                  using (HttpClient client = new HttpClient())
                  {
                        var response = await client.GetAsync($"{BaseAPI.BaseCateringURL}/MenuFoodItems");
                        if (response.IsSuccessStatusCode)
                        {
                              var content = await response.Content.ReadAsStringAsync();
                              items = JsonConvert.DeserializeObject<List<MenuFoodItems>>(content);
                        }
                  }

                  return items;

            }

            public static async Task Delete(MenuFoodItems menuFoodItem)
            {
                  using (HttpClient client = new HttpClient())
                  {
                        var content = new StringContent(JsonConvert.SerializeObject(menuFoodItem), Encoding.UTF8, "application/json");

                        // add to request
                        var response = await client.DeleteAsync($"{BaseAPI.BaseCateringURL}/MenuFoodItems/");

                        if (!response.IsSuccessStatusCode)
                        {
                              throw new Exception("Failed to delete");
                        }
                  }
            }
      }
}
