using Newtonsoft.Json;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.API
{
    public class GuestAPIController : APIController<Guest>
    {
        public GuestAPIController(): base(APIType.Venues, "guest")
        {
            
        }

        public async Task<List<Guest>> GetList(int id)
        {
            List<Guest> item = default;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{BaseURL}/guest/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<List<Guest>>(content);
                }
            }

            return item;
        }
    }
}
