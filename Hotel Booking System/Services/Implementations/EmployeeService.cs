using Hotel_Booking_System.Data;
using Hotel_Booking_System.DTO.GetAllDtos;
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

            await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;

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

        public async Task<List<EmployeeGetAllDto>> GetAllEmployee()
        {
            var employees = await _context.employees.Include((id) => id.Hotel).ToListAsync();

            var newEmployeeGetAllDto = employees.Select(x => new EmployeeGetAllDto
            {
                Id = x.Id,
                FullName = x.FullName,
                Role = x.Role,
                Email = x.Email,
                HotelId = x.HotelId,
                HotelName = x.Hotel.Name
            }).ToList();

            return newEmployeeGetAllDto;
        }

        public async Task<EmployeeGetAllDto> GetEmployeeById(int id)
        {
            Employee employee = await _context.employees.Include((id) => id.Hotel).FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                var employeeGetAllDto = new EmployeeGetAllDto()
                {
                    Id= employee.Id,
                    FullName = employee.FullName,
                    Role = employee.Role,
                    Email = employee.Email,
                    HotelId= employee.HotelId,
                    HotelName= employee.Hotel.Name
                };
                return employeeGetAllDto;
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
