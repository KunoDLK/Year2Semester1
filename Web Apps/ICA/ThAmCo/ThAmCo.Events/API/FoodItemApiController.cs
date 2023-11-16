using Newtonsoft.Json;
using ThAmCo.Catering.Data;

namespace ThAmCo.Events.Data
{
    public static class ApiSettings
    {
        public static string BaseCateringURL { get; set; } = "https://localhost:7173/api";
    }

    public static class FoodItemApiController 
    {
        public static async Task<List<FoodItem>> GetAllItems()
        {
            List<FoodItem> items = new List<FoodItem>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{ApiSettings.BaseCateringURL}/FoodItems");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<FoodItem>>(content);
                }
            }

            return items;
        }

        public static async void DeleteItem(int foodItemId)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{ApiSettings.BaseCateringURL}/FoodItems/{foodItemId}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to delete");
                }
            }
        }


    }
}
