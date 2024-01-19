using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrimTrim.DAL;
using TrimTrim.Models;

namespace TrimTrim.Pages.ServiceMaster
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }

        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrimTrim.Models.Service Service { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Service.Add(Service);
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
