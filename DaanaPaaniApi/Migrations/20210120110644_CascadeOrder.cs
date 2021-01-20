using Microsoft.EntityFrameworkCore.Migrations;

namespace DaanaPaaniApi.Migrations
{
    public partial class CascadeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_OrderTempletes_OrderTempleteId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderTempletes");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderTempleteId",
                table: "OrderItems");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.CreateTable(
                name: "OrderTempletes",
                columns: table => new
                {
                    OrderTempleteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTempleteDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTempletes", x => x.OrderTempleteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderTempleteId",
                table: "OrderItems",
                column: "OrderTempleteId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_OrderTempletes_OrderTempleteId",
                table: "OrderItems",
                column: "OrderTempleteId",
                principalTable: "OrderTempletes",
                principalColumn: "OrderTempleteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
