using Microsoft.EntityFrameworkCore.Migrations;

namespace DaanaPaaniApi.Migrations
{
    public partial class AddOrderTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "Orders");
        }
    }
}
