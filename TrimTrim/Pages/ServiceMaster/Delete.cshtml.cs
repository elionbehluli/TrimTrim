using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrimTrim.DAL;

namespace TrimTrim.Pages.ServiceMaster
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrimTrim.Models.Service Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = await _context.Service.FirstOrDefaultAsync(m => m.Id == id);

            if (Service == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = await _context.Service.FindAsync(id);

            if (Service != null)
            {
                _context.Service.Remove(Service);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
