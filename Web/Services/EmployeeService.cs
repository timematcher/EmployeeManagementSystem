using EmpowerIDAwaisMunir.Domain.Interfaces.Repositories;
using EmpowerIDAwaisMunir.Domain.Interfaces.Services;
using EmpowerIDAwaisMunir.Domain.Models;

namespace EmpowerIDAwaisMunir.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _employeeRepository { get; set; } 
        public EmployeeService(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }
        public Employee CreateEmployee(Employee employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }

        public bool DeleteEmployee(long employeeId)
        {
            return (_employeeRepository.DeleteEmployee(employeeId));    
        }

        public IList<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public IList<Employee> GetEmployees(string keyword)
        {
            return _employeeRepository.GetEmployees(keyword);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

        public Employee GetEmployee(long id)
        {
            return _employeeRepository.GetEmployee(id);
        }
    }
}
