using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrimTrim.DAL;
using TrimTrim.Models;

namespace TrimTrim.Pages.Service
{
    public class IndexModel : PageModel
    {
        private readonly TrimTrim.DAL.AppDbContext _context;

        public IndexModel(TrimTrim.DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SearchModel Search { get; set; }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.ToListAsync();
            }
        }

        public void OnPost()
        {
            // Handle the search
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(Search?.SearchTerm))
            {
                query = query
                    .Where(p => EF.Functions.Like(p.ProductName, $"%{Search.SearchTerm}%"));
            }

            // Apply additional filters based on user-specified criteria
            if (Search?.MinPrice.HasValue ?? false)
            {
                query = query
                    .Where(p => p.Price >= Search.MinPrice.Value);
            }

            // Execute the final query
            Product = query.ToList();
        }
    }
}
