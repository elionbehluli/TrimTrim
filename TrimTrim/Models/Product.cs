using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrimTrim.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public required string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
