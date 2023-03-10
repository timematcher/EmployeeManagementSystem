using EmpowerIDAwaisMunir.Domain.Models;

namespace EmpowerIDAwaisMunir.Domain.Interfaces.Repositories
{
    public interface  IEmployeeRepository
    {
        public Employee CreateEmployee(Employee employee);
        public Employee GetEmployee(long id);
        public Boolean DeleteEmployee(long employeeId);
        public Boolean UpdateEmployee(Employee employee);
        public IList<Employee> GetAllEmployees();
        public IList<Employee> GetEmployees(string keyword);
    }
}
