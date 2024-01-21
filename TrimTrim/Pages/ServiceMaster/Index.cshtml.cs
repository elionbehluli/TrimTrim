using Microsoft.AspNetCore.Mvc.RazorPages;
using TrimTrim.DAL;
using Microsoft.EntityFrameworkCore;
using TrimTrim.Models;
using Microsoft.AspNetCore.Mvc;

namespace TrimTrim.Pages.ServiceMaster
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SearchModel Search { get; set; }
        public IList<TrimTrim.Models.Service> Service { get; set; }

        public async Task OnGetAsync()
        {
            Service = await _context.Service.ToListAsync();
        }

        public void OnPost()
        {
            // Handle the search
            if (!string.IsNullOrEmpty(Search?.SearchTerm))
            {
                Service = _context.Service
                    .Where(p => EF.Functions.Like(p.Name, $"%{Search.SearchTerm}%"))
                    .ToList();
            }
            else
            {
                // Load all data if no search term is provided
                Service = _context.Service.ToList();
            }
        }
    }
}
