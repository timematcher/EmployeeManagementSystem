using EmpowerIDAwaisMunir.Domain.Interfaces.Repositories;
using EmpowerIDAwaisMunir.Domain.Interfaces.Services;
using EmpowerIDAwaisMunir.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EmpowerIDAwaisMunir.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Employee CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee GetEmployee(long id)
        {
            return _context.Employees
                .Where(m => m.Id.Equals(id) && m.IsDeleted == false).FirstOrDefault() ?? new Employee() { Id = -1 };
        }

        public bool DeleteEmployee(long employeeId)
        {
            //int result = _context.Employees.Where(m => m.Id.Equals(employeeId)).ExecuteDelete();
            var employeeToDelete = _context.Employees.Where(m => m.Id.Equals(employeeId) && m.IsDeleted == false).FirstOrDefault();
            if (employeeToDelete != null)
            {
                employeeToDelete.IsDeleted = true;
                var result = _context.SaveChanges();
                return result > 0;
            }
            return false;
        }

        public IList<Employee> GetAllEmployees()
        {
            return _context.Employees.Where(m => m.IsDeleted == false).ToList();
        }

        public IList<Employee> GetEmployees(string keyword)
        {
            keyword = keyword.ToLower();
            return _context.Employees
                .Where(m => (m.FirstName.ToLower().Contains(keyword) ||
                            m.LastName.ToLower().Contains(keyword) ||
                            m.Email.ToLower().Contains(keyword)) &&
                            m.IsDeleted == false)
                .ToList();
        }

        public bool UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = _context.Employees.FirstOrDefault(m => m.Id.Equals(employee.Id) && m.IsDeleted == false);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = employee.FirstName ?? employeeToUpdate.FirstName;
                employeeToUpdate.LastName = employee.LastName ?? employeeToUpdate.LastName;
                employeeToUpdate.Department = employee.Department ?? employeeToUpdate.Department;
                employeeToUpdate.DateOfBirth = employee.DateOfBirth ?? employeeToUpdate.DateOfBirth;

                var result = _context.SaveChanges();
                return result > 0;
            }
            return false;
        }
    }
}
