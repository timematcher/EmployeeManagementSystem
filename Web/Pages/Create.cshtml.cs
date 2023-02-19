using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmpowerIDAwaisMunir.Data;
using EmpowerIDAwaisMunir.Domain.Models;

namespace EmpowerIDAwaisMunir.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EmpowerIDAwaisMunir.Data.ApplicationDbContext _context;
        
        public CreateModel(EmpowerIDAwaisMunir.Data.ApplicationDbContext context)
        {
            _context = context;
            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmpowerIDAwaisMunir.Domain.Models.Employee Employee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Employee.Created = DateTime.Now;
            Employee.Updated = null;
            Employee.IsDeleted = false;
            
          if (!ModelState.IsValid || _context.Employees == null || Employee == null)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
