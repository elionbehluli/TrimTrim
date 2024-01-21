using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace TrimTrim.Pages.Admin
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public class LoginInputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
            // Handle GET request
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Check if the user is in the "Admin" role
                    var user = await _userManager.FindByEmailAsync(Input.Email);

                    if (user != null)
                    {
                        var userId = user.Id;
                        var userName = user.UserName;
                        var userEmail = user.Email;

                        // Output the specific properties you are interested in
                        System.Diagnostics.Debug.WriteLine($"User ID: {userId}, UserName: {userName}, Email: {userEmail}");
                    }

                    //System.Environment.Exit(1);

                    var isInAdminRole = await _userManager.IsInRoleAsync(user, "Admin");

                    if (isInAdminRole)
                    {
                        // Redirect to the admin dashboard
                        return RedirectToPage("/Admin/AdminDashboard");
                    }
                    //else
                    //{
                    //    // Redirect to a different page for non-admin users
                    //    return RedirectToPage("/UserDashboard");
                    //}
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            // If we reach here, the login attempt failed, return to the login page
            return Page();
        }
    }
}
