using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TrimTrim.Models
{
    public class Appointments
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }

}
