using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TrimTrim.DAL;
using TrimTrim.Models;

namespace TrimTrim.Pages.Service
{
    //public enum SortOrder
    //{
    //    Ascending,
    //    Descending
    //}

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

        public async Task OnGetAsync(string? sort, TrimTrim.Models.SortOrder? sortOrder)
        {
            if (_context.Products != null)
            {
                IQueryable<Product> query = _context.Products;

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

                Product = await query.ToListAsync();
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
            Product = query.ToList();
        }

    }
}
