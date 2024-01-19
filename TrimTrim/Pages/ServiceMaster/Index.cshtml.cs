using Microsoft.AspNetCore.Mvc.RazorPages;
using TrimTrim.DAL;
using Microsoft.EntityFrameworkCore;

namespace TrimTrim.Pages.ServiceMaster
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<TrimTrim.Models.Service> Service { get; set; }

        public async Task OnGetAsync()
        {
            Service = await _context.Service.ToListAsync();
        }
    }
}
