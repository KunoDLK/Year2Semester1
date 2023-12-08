using System.Text;
using Newtonsoft.Json;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.API
{
    public class MenuFoodItemController : BaseAPI
      {
            public MenuFoodItemController() : base(APIType.Catering) { }

            public async void DeleteFoodItem(int foodId)
            {
                  var items = await Get();

                  var itemsToDelete = items.Where(x => x.FoodItemId == foodId).ToList();

                  foreach (var item in itemsToDelete)
                  {
                        Delete(item);
                  }
            }

            public async Task<List<MenuFoodItems>> Get()
            {

                  List<MenuFoodItems> items = new List<MenuFoodItems>();
                  using (HttpClient client = new HttpClient())
                  {
                        var response = await client.GetAsync($"{BaseURL}/MenuFoodItems");
                        if (response.IsSuccessStatusCode)
                        {
                              var content = await response.Content.ReadAsStringAsync();
                              items = JsonConvert.DeserializeObject<List<MenuFoodItems>>(content);
                        }
                  }

                  return items;

            }

            public async Task Delete(MenuFoodItems menuFoodItem)
            {
                  using (HttpClient client = new HttpClient())
                  {
                        var content = new StringContent(JsonConvert.SerializeObject(menuFoodItem), Encoding.UTF8, "application/json");

                        // add to request
                        var response = await client.DeleteAsync($"{BaseURL}/MenuFoodItems/");

                        if (!response.IsSuccessStatusCode)
                        {
                              throw new Exception("Failed to delete");
                        }
                  }
            }
      }
}
