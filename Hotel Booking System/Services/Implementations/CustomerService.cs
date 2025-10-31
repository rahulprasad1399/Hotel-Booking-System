using Hotel_Booking_System.Data;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Hotel_Booking_System.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly HotelDbContext _context;
        public CustomerService(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var result = await _context.customers.AddAsync(customer);
            Console.WriteLine("007 testing : ", result);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            Customer customer = await _context.customers.FirstOrDefaultAsync(x => x.Id == id);  
            if (customer == null)
            {
                return null;
            } else
            {
                _context.customers.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = await _context.customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = await _context.customers.FirstOrDefaultAsync(x => x.Id == id);  
            if(customer == null) {
                return null;
            } else
            {
                return customer;
            }
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            var customerFound = await _context.customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customerFound == null)
            {
                return null;
            } else
            {
                customerFound.FullName = customer.FullName;
                customerFound.Email = customer.Email;
                customerFound.PhoneNumber = customer.PhoneNumber;
                customerFound.IdProofNumber = customer.IdProofNumber;

                await _context.SaveChangesAsync();
                return customerFound;
            }
        }
    }
}
