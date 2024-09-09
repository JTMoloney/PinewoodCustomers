using Microsoft.AspNetCore.Mvc;
using PinewoodCustomers.Common.Models;

namespace PinewoodCustomers.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        // The logic here should probably be refactored to a Persistence layer

        // Static so that it stays consistent between instances
        private static List<Customer> _customers = new List<Customer>() { new Customer { Id = Guid.NewGuid(), Email = "test@email.com", Name = "Test Customer" } };

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Json(_customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(Guid id)
        {
            var matchingCustomer = _customers.SingleOrDefault(x => x.Id == id);

            return matchingCustomer != null ? Json(matchingCustomer) : NotFound(new { Message = $"Customer with Id {id} not found." });
        }

        [HttpPost]
        public IActionResult SaveCustomer(Customer customer)
        {
            // If we were using EntityFramework or another DB interface we could just use Update()...

            if (customer.IsCreate)
            {
                customer.Id = Guid.NewGuid();
                _customers.Add(customer);
            }
            else
            {
                var matchingCustomer = _customers.SingleOrDefault(x => x.Id == customer.Id);

                if (matchingCustomer != null)
                {
                    matchingCustomer.Name = customer.Name;
                    matchingCustomer.Email = customer.Email;
                }
                else
                {
                    return NotFound(new { Message = $"Customer with Id {customer.Id} not found." });
                }
            }

            return Json(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            var matchingCustomer = _customers.SingleOrDefault(x => x.Id == id);

            if (matchingCustomer == null)
            {
                return NotFound(new { Message = $"Customer with Id {id} not found." });
            }

            _customers.Remove(matchingCustomer);

            return Ok();
        }
    }
}
