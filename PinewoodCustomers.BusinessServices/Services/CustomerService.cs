using PinewoodCustomers.BusinessServices.Interfaces;
using PinewoodCustomers.Common.Models;

namespace PinewoodCustomers.BusinessServices.Services
{
    public class CustomerService : ApiCallingService, ICustomerService
    {
        public CustomerService(HttpClient httpClient) : base(httpClient) { }

        public async Task<Customer> SaveCustomer(Customer customer)
        {
            return await PostAsync<Customer>("api/Customer/SaveCustomer", customer);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await GetAsync<List<Customer>>("api/Customer/GetAllCustomers");
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await GetAsync<Customer>($"api/Customer/GetCustomer/{id}");
        }

        public async Task DeleteCustomerById(Guid id)
        {
            await DeleteAsync($"api/Customer/DeleteCustomer/{id}");
        }
    }
}
