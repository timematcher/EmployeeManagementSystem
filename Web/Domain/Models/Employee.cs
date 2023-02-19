using Microsoft.EntityFrameworkCore;

namespace EmpowerIDAwaisMunir.Domain.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
    }
}
