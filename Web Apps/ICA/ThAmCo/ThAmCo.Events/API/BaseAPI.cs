namespace ThAmCo.Events.API
{
      public class BaseAPI
      {
            private string _baseCateringURL = "https://localhost:7173/api";

            private string _baseVenuesURL = "https://localhost:7088/api";

            public string BaseURL { get; private set; }

            public enum APIType
            {
                  Catering,
                  Venues,
            }

            public BaseAPI(APIType type)
            {
                  BaseURL = type switch
                  {
                        APIType.Catering => _baseCateringURL,
                        APIType.Venues => _baseVenuesURL,
                        _ => throw new Exception("Unknown API Type given"),
                  };
            }
      }
}
