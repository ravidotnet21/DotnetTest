using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4_Razor.Model; 
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication4_Razor.Pages.BookList
{ 
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }[BindProperty]
        public ClassSchedule Student { get; set; }
        public  IActionResult OnGet(int? id)
        {
            Student = new ClassSchedule();
            if (id == null)
                return Page();
            Student =  _context.ClassSchedules.Find(id);
            return Page();
        }
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (Student.Id== 0)
                 _context.ClassSchedules.Add(Student);
            else
                _context.ClassSchedules.Update(Student);
                 _context.SaveChanges();
                return RedirectToPage("Index");
        }
    }
}
