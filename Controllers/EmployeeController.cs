using EmpowerIDAwaisMunir.Domain.Interfaces.Services;
using EmpowerIDAwaisMunir.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpowerIDAwaisMunir.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet("/emp")]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetAllEmployees();
        }
        // GET: api/<EmployeeController>
        [HttpGet("/find/{keyword}")]
        public IEnumerable<Employee> GetByKeyword(string keyword)
        {
            return _employeeService.GetEmployees(keyword);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("/get/{id}")]
        public Employee GetById(int id)
        {
            return _employeeService.GetEmployee(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var result = _employeeService.CreateEmployee(employee);
            return new JsonResult(result);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            var result = _employeeService.UpdateEmployee(employee);
            return new JsonResult(result);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int employeeId)
        {
            var result = (_employeeService.DeleteEmployee(employeeId));
            return new JsonResult(result);
        }
    }
}
