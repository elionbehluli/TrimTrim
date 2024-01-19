using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrimTrim.DAL;
using TrimTrim.Models;


namespace TrimTrim.Pages.AppointmentsMaster
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public Appointments Appointment { get; set; }

        public List<SelectListItem> UserOptions { get; set; }

        public CreateModel(AppDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public void OnGet()
        {
           PopulateUserOptions();
        }
       

        public IActionResult OnPost()
        {
            // Check the logged-in user's role
            var isAdmin = User.IsInRole("Admin");

            if (!ModelState.IsValid)
            {
                if (isAdmin)
                {
                    // If the user is an admin, repopulate user options and return to the page
                    PopulateUserOptions();
                }

                
            }

            try
            {
                // Ensure that the user is authenticated before creating the appointment
                var userId = _userManager.GetUserId(User);

                // Associate the appointment with the authenticated user
                Appointment.UserId = userId;

                // Add the appointment to the context and save changes
                _dbContext.Appointments.Add(Appointment);
                _dbContext.SaveChanges();

                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, display error message, etc.)
                ModelState.AddModelError(string.Empty, "An error occurred while saving the appointment.");

                if (isAdmin)
                {
                    // If the user is an admin, repopulate user options and return to the page
                    PopulateUserOptions();
                }

                return Page();
            }
        }
        private void PopulateUserOptions()
        {
            UserOptions = _userManager.Users
                .Select(u => new SelectListItem { Value = u.Id, Text = u.UserName })
                .ToList();
        }
    }

}
