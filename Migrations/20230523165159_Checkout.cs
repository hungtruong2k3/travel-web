using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Btl.Migrations
{
    public partial class Checkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckoutFistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckoutTotal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.CheckoutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkouts");
        }
    }
}
