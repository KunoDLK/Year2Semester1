using System.Text;
using System.Threading;
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
                HttpRequestMessage request = CreateRequestMessage(HttpMethod.Delete, CreateUri($"{BaseURL}/MenuFoodItems/"));
                request.Content = content;
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to delete");
                }
            }
        }

        private Uri? CreateUri(string? uri) =>
            string.IsNullOrEmpty(uri) ? null : new Uri(uri, UriKind.RelativeOrAbsolute);

        private HttpRequestMessage CreateRequestMessage(HttpMethod method, Uri? uri) =>
            new HttpRequestMessage(method, uri) { Version = Version.Parse("1.1"), VersionPolicy = HttpVersionPolicy.RequestVersionOrLower };
    }
}
