using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Btl.Migrations
{
    public partial class TravelLocation : Migration
    {
        [AllowAnonymous]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelLocation",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LocationDescription = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LocationImage = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LocalID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelLocation", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_TravelLocation_Local_LocalID",
                        column: x => x.LocalID,
                        principalTable: "Local",
                        principalColumn: "LocalID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelLocation_LocalID",
                table: "TravelLocation",
                column: "LocalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelLocation");
        }
    }
}
