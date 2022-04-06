using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4_Razor.Model;

namespace WebApplication4_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ClassSchedule> ClassSchedules { get; set; }
        public async Task OnGet()
        {
            ClassSchedules = await _context.ClassSchedules.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (id == 0)
                return NotFound();
            var bookindb = await _context.ClassSchedules.FindAsync(id);
            if (bookindb == null)
                return NotFound();
            _context.ClassSchedules.Remove(bookindb);
          await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
