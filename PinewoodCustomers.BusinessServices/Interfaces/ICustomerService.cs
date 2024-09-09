using PinewoodCustomers.Common.Models;

namespace PinewoodCustomers.BusinessServices.Interfaces
{
    public interface ICustomerService
    {
        public Task<Customer> SaveCustomer(Customer customer);
        public Task<List<Customer>> GetAllCustomers();
        public Task<Customer> GetCustomerById(Guid id);
        public Task DeleteCustomerById(Guid id);
    }
}
