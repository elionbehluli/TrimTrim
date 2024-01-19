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

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.ToListAsync();
            }
        }
    }
}
