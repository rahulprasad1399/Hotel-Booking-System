using Hotel_Booking_System.Data;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HotelDbContext _context;
        public EmployeeService(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {

            Employee newEmployee = new Employee();
            newEmployee.FullName = employee.FullName;
            newEmployee.Role = employee.Role;
            newEmployee.Email = employee.Email;
            newEmployee.HotelId = employee.HotelId;

            var createdEmployee = await _context.employees.AddAsync(newEmployee);
            var savedToDb = await _context.SaveChangesAsync();
            if(savedToDb == 1)
            {
                return createdEmployee.Entity;
            } else
            {
                return null;
            }
            
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            Employee employeeToBeDeleted = await _context.employees.FirstOrDefaultAsync((x) => x.Id == id);
            if (employeeToBeDeleted != null)
            {
                _context.employees.Remove(employeeToBeDeleted);
                await _context.SaveChangesAsync();
                return employeeToBeDeleted;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            var empoyees = await _context.employees.ToListAsync();
            return empoyees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = await _context.employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            Employee employeeToBeUpdated = await _context.employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employeeToBeUpdated == null)
            {
                return null;
            }
            else
            {
                employeeToBeUpdated.FullName = employee.FullName;
                employeeToBeUpdated.Role = employee.Role;
                employeeToBeUpdated.Email = employee.Email;
                employeeToBeUpdated.HotelId = employee.HotelId;

                await _context.SaveChangesAsync();
                return employeeToBeUpdated;
            }
        }
    }
}
