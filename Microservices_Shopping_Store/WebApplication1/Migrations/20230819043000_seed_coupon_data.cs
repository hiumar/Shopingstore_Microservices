using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mano.Services.Coupan.Migrations
{
    /// <inheritdoc />
    public partial class seed_coupon_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coupans",
                columns: new[] { "CoupanId", "CoupanCode", "CoupanDisCount", "MinAmount" },
                values: new object[,]
                {
                    { 1, "1002", 12.0, 3 },
                    { 2, "1005", 50.0, 10 },
                    { 3, "1007", 30.0, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupans",
                keyColumn: "CoupanId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "coupans",
                keyColumn: "CoupanId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "coupans",
                keyColumn: "CoupanId",
                keyValue: 3);
        }
    }
}
