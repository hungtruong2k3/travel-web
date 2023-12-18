using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Btl.Migrations
{
    public partial class LocalProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    LocalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.LocalID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocalID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Local_LocalID",
                        column: x => x.LocalID,
                        principalTable: "Local",
                        principalColumn: "LocalID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_LocalID",
                table: "Product",
                column: "LocalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Local");
        }
    }
}
