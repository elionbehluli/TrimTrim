using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrimTrim.Models;

namespace TrimTrim.DAL
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Appointments> Appointments { get; set; }

    }
}
