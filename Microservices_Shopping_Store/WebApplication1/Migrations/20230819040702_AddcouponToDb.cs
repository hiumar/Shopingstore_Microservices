using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mano.Services.Coupan.Migrations
{
    /// <inheritdoc />
    public partial class AddcouponToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coupans",
                columns: table => new
                {
                    CoupanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoupanCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoupanDisCount = table.Column<double>(type: "float", nullable: false),
                    MinAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupans", x => x.CoupanId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coupans");
        }
    }
}
