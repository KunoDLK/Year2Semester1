using System.Text;
using Newtonsoft.Json;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.API
{
    public class MenuController
    {
       
            public static async Task<List<Menu>> Get()
            {
                List<Menu> items = new List<Menu>();
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync($"{BaseAPI.BaseCateringURL}/Menu");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        items = JsonConvert.DeserializeObject<List<Menu>>(content);
                    }
                }

                return items;
            }

            public static async Task<Menu> Get(int id)
            {
                Menu item = null;

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync($"{BaseAPI.BaseCateringURL}/Menu/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        item = JsonConvert.DeserializeObject<Menu>(content);
                    }
                }

                return item;
            }

            public static async Task Delete(int id)
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.DeleteAsync($"{BaseAPI.BaseCateringURL}/Menu/{id}");

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Failed to delete");
                    }
                }
            }

            public static async Task Put(Menu menu)
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(menu), Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{BaseAPI.BaseCateringURL}/Menu/{menu.MenuId}", content);
                }
            }

            public static async Task Post(Menu menu)
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(menu), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{BaseAPI.BaseCateringURL}/Menu", content);
                }
            }
        
    }
}
