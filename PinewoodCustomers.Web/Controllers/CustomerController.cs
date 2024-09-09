using Microsoft.AspNetCore.Mvc;
using PinewoodCustomers.BusinessServices.Interfaces;
using PinewoodCustomers.Common.Models;

namespace PinewoodCustomers.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomers();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Details", new Customer());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute]Guid id)
        {
            var customer = await _customerService.GetCustomerById(id);

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Customer customer)
        {
            var res = await _customerService.SaveCustomer(customer);

            return RedirectToAction("Index");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerService.DeleteCustomerById(id);

            return Ok();
        }
    }
}
