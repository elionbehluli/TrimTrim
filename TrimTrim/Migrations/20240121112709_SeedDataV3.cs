using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrimTrim.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed data for Products
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Disinfectant Spray", 10, 100 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Hair Wax", 10, 50 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Shaving Brush", 7, 100 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Trimmer", 29.99, 50 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Shear", 9.99, 20 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Thinning scissors", 9.99, 17 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Neck dusters", 3, 100 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Shaving cream", 7, 50 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Spray", 14.99, 25 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Razor", 5, 60 });
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Shaving Brush", 4.99, 30 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Gel", 7, 40 });
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Hair Conditioner", 29.99, 17 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductName", "Price", "Qty" },
                values: new object[] { "Face Mask", 9.99, 20 });

            // Seed data for Service
            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Haircut", "5" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Beard", "4" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Beard Shaving", "2" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Hair Shaving", "3" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Mask", "5" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Styling with hair gel or pomade", "1" });

            migrationBuilder.InsertData(
               table: "Service",
               columns: new[] { "Name", "Price" },
               values: new object[] { "Hair coloring", "20" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Name", "Price" },
                values: new object[] { "Hair Wash", "2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
