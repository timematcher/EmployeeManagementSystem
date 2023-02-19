using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpowerIDAwaisMunir.Data;
using EmpowerIDAwaisMunir.Domain.Models;

namespace EmpowerIDAwaisMunir.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly EmpowerIDAwaisMunir.Data.ApplicationDbContext _context;

        public DeleteModel(EmpowerIDAwaisMunir.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpowerIDAwaisMunir.Domain.Models.Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                Employee = employee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                Employee = employee;
                //_context.Employees.Remove(Employee);

                Employee = _context.Employees.Where(m => m.Id.Equals(Employee.Id)).First();

                Employee.IsDeleted = true;
                _context.Update(Employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
