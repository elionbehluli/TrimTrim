using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrimTrim.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordColumnToAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Admin",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
            table: "Admin",
            keyColumn: "Id", // Assuming Id is the primary key
            keyValue: 1, // Update with the correct Id
            column: "Password", // Column name
            value: "Admin");

        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admin");
        }
    }
}
