using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrimTrim.Models;
using TrimTrim.Pages.Admin;

namespace TrimTrim.Pages.User
{
    [Authorize(Policy = "UserOnly")]
    public class UserDashboardModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AdminDashboardModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public string UserName { get; private set; }
        public UserDashboardModel(SignInManager<IdentityUser> signInManager, ILogger<AdminDashboardModel> logger, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;

        }

        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                UserName = user.UserName;
            }
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            return RedirectToPage("/Index");
        }
    }
}
