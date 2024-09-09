namespace PinewoodCustomers.BusinessServices.Interfaces
{
    public interface IApiCallingService
    {
        public Task<T> GetAsync<T>(string url);
        public Task<T> PostAsync<T>(string url, object data);
        public Task DeleteAsync(string url);
    }
}
