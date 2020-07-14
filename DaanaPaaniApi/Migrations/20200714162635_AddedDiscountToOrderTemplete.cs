using Microsoft.EntityFrameworkCore.Migrations;

namespace DaanaPaaniApi.Migrations
{
    public partial class AddedDiscountToOrderTemplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderTempleteId",
                table: "Discounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_OrderTempleteId",
                table: "Discounts",
                column: "OrderTempleteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_OrderTempletes_OrderTempleteId",
                table: "Discounts",
                column: "OrderTempleteId",
                principalTable: "OrderTempletes",
                principalColumn: "OrderTempleteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_OrderTempletes_OrderTempleteId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_OrderTempleteId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "OrderTempleteId",
                table: "Discounts");
        }
    }
}
