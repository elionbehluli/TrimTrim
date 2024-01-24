using Microsoft.AspNetCore.Mvc.RazorPages;
using TrimTrim.DAL;
using Microsoft.EntityFrameworkCore;
using TrimTrim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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

        public async Task OnGetAsync(string? sort, TrimTrim.Models.SortOrder? sortOrder)
        {
            IQueryable<TrimTrim.Models.Service> query = _context.Service;

            // Apply sorting based on the sort parameter and sort order
            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    if (sortOrder == TrimTrim.Models.SortOrder.Ascending)
                    {
                        query = query.OrderBy(p => p.Price);
                    }
                    else if (sortOrder == TrimTrim.Models.SortOrder.Descending)
                    {
                        query = query.OrderByDescending(p => p.Price);
                    }
                }
                // Add more cases for other sorting options if needed
            }

            Service = await query.ToListAsync();
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

            // Apply sorting based on the Price property
            if (Search.SortOrder == TrimTrim.Models.SortOrder.Ascending)
            {
                query = query.OrderBy(p => p.Price);
            }
            else if (Search.SortOrder == TrimTrim.Models.SortOrder.Descending)
            {
                query = query.OrderByDescending(p => p.Price);
            }

            // Execute the final query
            Service = query.ToList();
        }
    
    }
}
