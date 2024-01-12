using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrimTrim.DAL;

namespace TrimTrim.Pages.Admin
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        private readonly ILogger<LoginModel> _logger;
        private readonly AppDbContext _context; // Replace YourDbContext with your DbContext class name

        public LoginModel(ILogger<LoginModel> logger, AppDbContext context) // Inject DbContext
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            // Query Admin table by Email
            var admin = _context.Admin.FirstOrDefault(a => a.Email == Email);

            // Check if admin exists and verify password (implement password hashing logic)
            if (admin != null && admin.Password == Password) // Replace with actual password hashing and verification logic
            {
                // Authentication successful, redirect to ProductMaster page
                return RedirectToPage("/ProductMaster/Index"); // Redirect to ProductMaster page
            }
            else
            {
                // Authentication failed, handle error (e.g., display error message)
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page(); // Stay on the login page and display error message
            }
        }
    }
}
