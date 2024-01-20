using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrimTrim.DAL;
using TrimTrim.Models;

namespace TrimTrim.Pages.User
{
    public class ManageAppointmentsModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _dbContext;

        public List<Appointments> UserAppointments { get; set; }

        public ManageAppointmentsModel(UserManager<IdentityUser> userManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            // Fetch appointments for the current user
            UserAppointments = _dbContext.Appointments
                .Where(appointment => appointment.UserId == user.Id)
                .ToList();

            return Page();
        }

    }
}
