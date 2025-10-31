using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<Customer> CreateCustomer(CustomerPostDto customerPostDto)
        {

            Customer customer = new Customer
            {
                FullName = customerPostDto.FullName,
                PhoneNumber = customerPostDto.PhoneNumber,
                IdProofNumber = customerPostDto.IdProofNumber,
                Email = customerPostDto.Email
            };

            var createdCustomer = await _customerService.CreateCustomer(customer);
            return createdCustomer;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            List<Customer> customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            Customer customer = await _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            Customer customer = await _customerService.DeleteCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerPostDto customerPostDto)
        {
            Customer updatedCustomer = new Customer
            {
                FullName = customerPostDto.FullName,
                Email = customerPostDto.Email,
                PhoneNumber = customerPostDto.PhoneNumber,
                IdProofNumber = customerPostDto.IdProofNumber,
            };

            var customer = await _customerService.UpdateCustomer(id, updatedCustomer);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }

    }
}
