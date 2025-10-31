using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            List<Employee> employees = await _employeeService.GetAllEmployee();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            Employee employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeePostDto employeePostDto)
        {

            if(employeePostDto == null)
            {
                return BadRequest("Employee data is required");
            }

            Employee employee = new Employee();
            employee.FullName = employeePostDto.FullName;
            employee.Role = employeePostDto.Role;
            employee.Email = employeePostDto.Email;
            employee.HotelId = employeePostDto.HotelId;

            Employee newEmployee = await _employeeService.CreateEmployee(employee);

            if(newEmployee == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError ,"Error Creating Employee")
            }

            return Ok(newEmployee);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee employeeToBeDeleted = await _employeeService.DeleteEmployee(id);
            if (employeeToBeDeleted == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employeeToBeDeleted);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeePostDto employeePostDto)
        {


            Employee updateEmployee = new Employee();
            updateEmployee.FullName = employeePostDto.FullName;
            updateEmployee.Role = employeePostDto.Role;
            updateEmployee.Email = employeePostDto.Email;
            updateEmployee.HotelId = employeePostDto.HotelId;

            Employee employee = await _employeeService.UpdateEmployee(id, updateEmployee);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
    }
}
