using System.Text;
using Newtonsoft.Json;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.API
{
    public static class FoodItemController
    {
        public static async Task<List<FoodItem>> Get()
        {
            List<FoodItem> items = new List<FoodItem>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{BaseAPI.BaseCateringURL}/FoodItems");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<FoodItem>>(content);
                }
            }

            return items;
        }

        public static async Task<FoodItem> Get(int id)
        {
            FoodItem item = null;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{BaseAPI.BaseCateringURL}/FoodItems/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<FoodItem>(content);
                }
            }

            return item;
        }

        public static async Task Delete(int foodItemId)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{BaseAPI.BaseCateringURL}/FoodItems/{foodItemId}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to delete");
                }
            }
        }

        public static async Task Put(FoodItem foodItem)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(foodItem), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{BaseAPI.BaseCateringURL}/FoodItems/{foodItem.FoodItemId}", content);
            }
        }

        public static async Task Post(FoodItem foodItem)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(foodItem), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{BaseAPI.BaseCateringURL}/FoodItems", content);
            }
        }
    }
}
