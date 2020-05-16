using Microsoft.EntityFrameworkCore.Migrations;

namespace DaanaPaaniApi.Migrations
{
    public partial class addedLocationInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationInfos",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false),
                    lat = table.Column<string>(nullable: true),
                    lng = table.Column<string>(nullable: true),
                    placeId = table.Column<string>(nullable: true),
                    formatted_address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInfos", x => x.customerId);
                    table.ForeignKey(
                        name: "FK_LocationInfos_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationInfos");
        }
    }
}
