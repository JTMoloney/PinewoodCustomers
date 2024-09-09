using PinewoodCustomers.BusinessServices.Interfaces;
using System.Net.Http.Json;

namespace PinewoodCustomers.BusinessServices.Services
{
    // A base ApiCallingService, for scalability
    public class ApiCallingService : IApiCallingService
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseApiUrl;

        public ApiCallingService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
            _baseApiUrl = "https://localhost:7155"; // Should really put this in appsettings
        }

        public async Task<T> GetAsync<T>(string url)
        {
            if (!url.StartsWith("/"))
                url = $"/{url}";

            var response = await _httpClient.GetAsync($"{_baseApiUrl}{url}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            if (!url.StartsWith("/"))
                url = $"/{url}";
            
            var response = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}{url}", data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task DeleteAsync(string url)
        {
            if (!url.StartsWith("/"))
                url = $"/{url}";

            var response = await _httpClient.DeleteAsync($"{_baseApiUrl}{url}");
            response.EnsureSuccessStatusCode();
        }
    }
}
