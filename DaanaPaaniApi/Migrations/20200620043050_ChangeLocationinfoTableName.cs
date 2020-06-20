using Microsoft.EntityFrameworkCore.Migrations;

namespace DaanaPaaniApi.Migrations
{
    public partial class ChangeLocationinfoTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationInfos_Customers_customerId",
                table: "LocationInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationInfos",
                table: "LocationInfos");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "LocationInfos",
                newName: "Locations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Customers_customerId",
                table: "Locations",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Customers_customerId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "LocationInfos");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationInfos",
                table: "LocationInfos",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationInfos_Customers_customerId",
                table: "LocationInfos",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
