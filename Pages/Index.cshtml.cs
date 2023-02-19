using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using EmpowerIDAwaisMunir.Data;
using EmpowerIDAwaisMunir.Domain.Models;


namespace EmpowerIDAwaisMunir.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        //public IndexModel(EmpowerIDAwaisMunir.Data.ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //public IndexModel(EmpowerIDAwaisMunir.Data.ApplicationDbContext context)
        //{
        //    _logger = logger;
        //    _context = context;
        //}
        //public void OnGet()
        //{

        //}
        private readonly EmpowerIDAwaisMunir.Data.ApplicationDbContext _context;

        
        public IndexModel(EmpowerIDAwaisMunir.Data.ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _logger = logger;   
            _context = context;
        }
        
        public IList<EmpowerIDAwaisMunir.Domain.Models.Employee> Employee { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees.ToListAsync();
            }
        }
    }
}