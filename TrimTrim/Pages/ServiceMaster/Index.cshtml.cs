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
            IQueryable<TrimTrim.Models.Service> query = _context.Service;

            if (!string.IsNullOrEmpty(Search?.SearchTerm))
            {
                query = query
                    .Where(p => EF.Functions.Like(p.Name, $"%{Search.SearchTerm}%"));
            }

            // Apply additional filters based on user-specified criteria
            if (Search?.MinPrice.HasValue ?? false)
            {
                query = query
                    .Where(p => (double)p.Price >= Search.MinPrice.Value);
            }

            // Execute the final query
            Service = query.ToList();
        }
    
    }
}
