using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TrimTrim.Pages.Admin
{
    //[Authorize(Policy = "AdminOnly")]
    public class UserListModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserListModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IList<IdentityUser> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DeleteUserId { get; set; }


        public async Task OnGetAsync()
        {
            var allUsers = await _userManager.Users.ToListAsync();

            // Filter users who do not have the "Admin" role in-memory
            Users = allUsers.Where(u => !_userManager.IsInRoleAsync(u, "Admin").Result).ToList();

        }

        [HttpGet]
        [Route("Admin/FetchUsers")]
        public async Task<IActionResult> OnGetFetchUsersAsync()
        {
            var allUsers = await _userManager.Users.ToListAsync();

            // Filter users who do not have the "Admin" role
            var users = allUsers.Where(u => !_userManager.IsInRoleAsync(u, "Admin").Result).Select(u => new
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            });

            return new JsonResult(allUsers);
        }
        public async Task<IActionResult> OnPostDeleteUserAsync()
        {
            var user = await _userManager.FindByIdAsync(DeleteUserId);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToPage();
            }

            return Page(); // Reload the page even on failure
        }
    }
}
