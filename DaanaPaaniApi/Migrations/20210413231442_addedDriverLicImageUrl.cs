using Microsoft.EntityFrameworkCore.Migrations;

namespace DaanaPaaniApi.Migrations
{
    public partial class addedDriverLicImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverAddresses");

            migrationBuilder.AddColumn<string>(
                name: "LicImageUrl",
                table: "Drivers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicImageUrl",
                table: "Drivers");

            migrationBuilder.CreateTable(
                name: "DriverAddresses",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverAddresses", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_DriverAddresses_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
