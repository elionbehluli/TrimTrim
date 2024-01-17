using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrimTrim.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminUserPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<IdentityUser>();

            migrationBuilder.Sql($"UPDATE AspNetUsers SET PasswordHash = '{hasher.HashPassword(null, "Admin123.")}' WHERE Id = '1'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
