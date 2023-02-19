using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmpowerIDAwaisMunir.Data;
using EmpowerIDAwaisMunir.Domain.Models;

namespace EmpowerIDAwaisMunir
{
    public class DetailsModel : PageModel
    {
        private readonly EmpowerIDAwaisMunir.Data.ApplicationDbContext _context;

        public DetailsModel(EmpowerIDAwaisMunir.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Employee Employee { get; set; } = default!; 

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
    }
}
