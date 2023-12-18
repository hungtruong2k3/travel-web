using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Btl.Migrations
{
    public partial class initUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
