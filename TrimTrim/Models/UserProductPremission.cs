using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrimTrim.Models
{
    public class UserProductPremission
    {
        [Required]
        public int Id { get; set; }

        public string UserId { get; set; } // Foreign Key
        public IdentityUser User { get; set; }

        public int ProductId { get; set; } // Foreign Key
        public Product Product { get; set; }

    }
}
