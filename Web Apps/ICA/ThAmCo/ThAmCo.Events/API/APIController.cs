using Newtonsoft.Json;
using System.Text;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.API   
{
      public class APIController<T> : BaseAPI
      {
            private string URLExtension { get; set; }

            public APIController(APIType type, string urlExtension) : base(type)
            {
                  URLExtension = urlExtension;
            }

            public async Task<List<T>> Get()
            {
                  List<T> items = new List<T>();
                  using (HttpClient client = new HttpClient())
                  {
                        var response = await client.GetAsync($"{BaseURL}/{URLExtension}");
                        if (response.IsSuccessStatusCode)
                        {
                              var content = await response.Content.ReadAsStringAsync();
                              items = JsonConvert.DeserializeObject<List<T>>(content);
                        }
                  }

                  return items;
            }

            public async Task<T> Get(int id)
            {
                  T item = default;

                  using (HttpClient client = new HttpClient())
                  {
                        var response = await client.GetAsync($"{BaseURL}/{URLExtension}/{id}");
                        if (response.IsSuccessStatusCode)
                        {
                              var content = await response.Content.ReadAsStringAsync();
                              item = JsonConvert.DeserializeObject<T>(content);
                        }
                  }

                  return item;
            }

            public async Task Delete(int id)
            {
                  using (HttpClient client = new HttpClient())
                  {
                        var response = await client.DeleteAsync($"{BaseURL}/{URLExtension}/{id}");

                        if (!response.IsSuccessStatusCode)
                        {
                              throw new Exception("Failed to delete");
                        }
                  }
            }

            public async Task Put(T EventType)
            {
                  using (HttpClient client = new HttpClient())
                  {
                        var content = new StringContent(JsonConvert.SerializeObject(EventType), Encoding.UTF8, "application/json");
                        var response = await client.PutAsync($"{BaseURL}/{URLExtension}", content);
                  }
            }

            public async Task Post(T eventType)
            {
                  using (HttpClient client = new HttpClient())
                  {
                        var content = new StringContent(JsonConvert.SerializeObject(eventType), Encoding.UTF8, "application/json");
                        var response = await client.PostAsync($"{BaseURL}/{URLExtension}", content);
                  }
            }
      }
}
