using Microsoft.EntityFrameworkCore;
using TrimTrim.Models;

namespace TrimTrim.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
    }
}
