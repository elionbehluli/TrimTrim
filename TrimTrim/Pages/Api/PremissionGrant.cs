using Microsoft.AspNetCore.Mvc;
using TrimTrim.DAL;
using TrimTrim.Models;

namespace TrimTrim.Pages.Api
{
    [Route("api/admin/premissiongrant")]
    [ApiController]
    public class PremissionGrant
    {
        private readonly AppDbContext _context; // Replace with your actual DbContext

        public PremissionGrant(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult GrantPermission([FromBody] GrantPermissionModel model)
        {
            try
            {
                // Retrieve the product from the database
                var product = _context.Products.Find(model.ProductId);

                if (product == null)
                {
                    return new ObjectResult(new { message = "Product not found" })
                    {
                        StatusCode = 404
                    };
                }

                // Implement the logic to grant permission for the specified product and users
                foreach (var user in model.Users)
                {
                    // Check if the user exists in the database
                    var existingUser = _context.Users.Find(user.Id);

                    if (existingUser != null)
                    {
                        // Perform your permission logic here, e.g., update a UserProductPermission table
                        // This is just an example, modify it based on your actual requirements
                        var permission = new TrimTrim.Models.UserProductPremission
                        {
                            UserId = user.Id,
                            ProductId = model.ProductId,
                            // Add other fields as needed
                        };

                        _context.UserProductPremissions.Add(permission);
                    }
                }

                _context.SaveChanges();

                return new ObjectResult(new { message = "Permissions granted successfully" })
                {
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { message = $"Error granting permissions: {ex.Message}" })
                {
                    StatusCode = 400
                };
            }
        }
    }
}
