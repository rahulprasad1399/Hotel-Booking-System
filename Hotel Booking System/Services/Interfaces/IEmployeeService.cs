using Hotel_Booking_System.DTO.GetAllDtos;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeGetAllDto>> GetAllEmployee();
        Task<EmployeeGetAllDto> GetEmployeeById(int id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
