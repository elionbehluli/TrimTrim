using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrimTrim.Areas.Identity.Pages.Shared
{
    public class _LoginPartialModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public _LoginPartialModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Optional: If you need additional properties or methods in the model, you can add them here.

        public void OnGet()
        {
            // Optional: If you need to perform some initialization logic, you can do it here.
        }
    }
}
