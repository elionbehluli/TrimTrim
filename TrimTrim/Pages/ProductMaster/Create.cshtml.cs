using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrimTrim.DAL;
using TrimTrim.Models;

namespace TrimTrim.Pages.Service
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly TrimTrim.DAL.AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(TrimTrim.DAL.AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        [BindProperty]
        public IFormFile PhotoUpload { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            //if (!ModelState.IsValid || _context.Products == null || Product == null)
            //{
            //    return Page();
            //}

            // Check if a file was uploaded
            if (PhotoUpload != null && PhotoUpload.Length > 0)
            {
                

                // Get the path to wwwroot/images
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                // Generate a unique filename
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + PhotoUpload.FileName;
                
                // Combine the path to the upload folder with the unique filename
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                // Save the file to disk
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await PhotoUpload.CopyToAsync(fileStream);
                }

                // Set the PhotoPath property of the Product
                Product.PhotoPath = uniqueFileName;
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
