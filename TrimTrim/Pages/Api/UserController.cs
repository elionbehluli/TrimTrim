using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrimTrim.Pages.Api
{
    [Route("api/admin/users")]
    [ApiController]
    public class UserController
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var allUsers = await _userManager.Users.ToListAsync();

            // Filter users who do not have the "Admin" role
            var users = allUsers.Where(u => !_userManager.IsInRoleAsync(u, "Admin").Result).Select(u => new
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            });

            return new JsonResult(users);
        }
    }
}
