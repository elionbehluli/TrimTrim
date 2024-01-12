using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrimTrim.Models
{
    [Table("Admin")]
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Bio { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
