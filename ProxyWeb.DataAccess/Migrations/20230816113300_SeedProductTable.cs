using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProxyWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "Price", "Price100", "Price50", "PriceList", "Title" },
                values: new object[,]
                {
                    { 1, "Billy Spark", "Praesent vitae sodales libero", "SW999999001", 90.0, 80.0, 85.0, 99.0, "Fortune of Time" },
                    { 2, "Abby Muscles", "Praesent vitae sodales libero", "WS33333301", 30.0, 20.0, 25.0, 40.0, "Cotton Candy" },
                    { 3, "Nancy Hoover", "Praesent vitae sodales libero", "CAW777777701", 30.0, 30.0, 30.0, 30.0, "Dark Skies" },
                    { 4, "Julian Button", "Praesent vitae sodales libero", "RIT055555501", 50.0, 35.0, 40.0, 55.0, "Vanish in the Sunset" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
