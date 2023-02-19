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
    public class IndexModel : PageModel
    {
        private readonly EmpowerIDAwaisMunir.Data.ApplicationDbContext _context;

        public IndexModel(EmpowerIDAwaisMunir.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees.ToListAsync();
            }
        }
    }
}
