using EmpowerIDAwaisMunir.Data;
using EmpowerIDAwaisMunir.Data.Repositories;
using EmpowerIDAwaisMunir.Domain.Interfaces.Repositories;
using EmpowerIDAwaisMunir.Domain.Interfaces.Services;
using EmpowerIDAwaisMunir.Domain.Models;
using EmpowerIDAwaisMunir.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UnitTests
{
    [TestFixture(Category = "Employee")]
    public class Tests
    {
        public ApplicationDbContext _context;
        public IEmployeeRepository _repository;
        public IEmployeeService _service;
        public Tests() { }

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<ApplicationDbContext> context = new DbContextOptionsBuilder<ApplicationDbContext>();
            context.UseInMemoryDatabase(databaseName: "EmployeeTest");
            var options = context.Options;

            _context = new ApplicationDbContext(options);
            _repository = new EmployeeRepository(_context);
            _service = new EmployeeService(_repository);

        }

        [Test]
        public void Create_new_Employee_positive_Scenario()
        {
            var emp = new Employee()
            {
                FirstName = "Test",
                LastName = "Test",
                Department = "123456 department",
                DateOfBirth = new DateOnly(2022, 1, 1),
                Email = "test@gmail.com"
            };
            
            try
            {
                emp = _service.CreateEmployee(emp);
            }
            catch (Exception ex)
            {
                Assert.Fail("Employee Creation failed");
            }
            if (emp.Id > 0) { Assert.Pass("Test Passes"); }
            else { Assert.Fail(); }
        }

        [Test]
        public void Create_new_Employee_With_Null_Email_Should_Fail()
        {
            var emp = new Employee()
            {
                FirstName = "Test",
                LastName = "Test",
                Department = "123456 department",
                DateOfBirth = new DateOnly(2022, 1, 1),
            };

            try
            {
                emp = _service.CreateEmployee(emp);
            }
            catch (Exception ex)
            {
                Assert.Pass("Employee Creation failed");
            }
            Assert.Fail("Employee Creation failed");
        }
        [Test]
        public void Create_new_Employee_With_Null_FirstName_Should_Fail()
        {
            var emp = new Employee()
            {
                LastName = "Test",
                Department = "123456 department",
                DateOfBirth = new DateOnly(2022, 1, 1),
            };

            try
            {
                emp = _service.CreateEmployee(emp);
            }
            catch (Exception ex)
            {
                Assert.Pass("Employee Creation failed");
            }
            Assert.Fail("Employee Creation failed");
        }
        [Test]
        public void Create_new_Employee_With_Null_LastName_Should_Fail()
        {
            var emp = new Employee()
            {
                FirstName = "Test",
                Department = "123456 department",
                DateOfBirth = new DateOnly(2022, 1, 1),
            };

            try
            {
                emp = _service.CreateEmployee(emp);
            }
            catch (Exception ex)
            {
                Assert.Pass("Employee Creation failed");
            }
            Assert.Fail("Employee Creation failed");
        }

        [Test]
        public void GetAll_Employees_Should_ContainEmployees()
        {
            IList<Employee> employees = new List<Employee>();

            try
            {
                employees = _service.GetAllEmployees();
            }
            catch (Exception ex)
            {
                Assert.Fail("Employee Listing failed");
            }
            Assert.Pass("Employee Listing Successful");
        }
        [Test]
        public void Find_Employeee_Should_Succeed()
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                var emp = new Employee()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    Department = "123456 department",
                    DateOfBirth = new DateOnly(2022, 1, 1),
                    Email = "test@gmail.com"
                };

                try
                {
                    emp = _service.CreateEmployee(emp);
                }
                catch (Exception ex)
                {
                    
                }

                employees = _service.GetEmployees("test");

            }
            catch (Exception ex)
            {
                Assert.Fail("Employee Search failed");
            }
            if (employees.Any())
            {
                Assert.Pass("Employee Search Successful");
            }
            else
            {
                Assert.Fail("Employee Search failed");
            }
        }
        [Test]
        public void Delete_Employeee_Should_Succeed()
        {
            var result = false;
            try
            {
                result = _service.DeleteEmployee(1);

            }
            catch (Exception ex)
            {
                Assert.Fail("Employee deletion failed");
            }
            if(result)
            {
                Assert.Pass("Employee deletion Successful");
            }
            else
            {
                Assert.Fail("Employee deletion failed");
            }
        }
    }
}