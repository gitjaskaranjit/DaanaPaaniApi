using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DaanaPaaniApi.Migrations
{
    public partial class addedInvoiceEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicImageUrl",
                table: "Drivers");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    CarriedBalance = table.Column<decimal>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    InvoiceStatus = table.Column<int>(nullable: false),
                    InvoiceTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLine",
                columns: table => new
                {
                    InvoiceLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ItemPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLine", x => x.InvoiceLineId);
                    table.ForeignKey(
                        name: "FK_InvoiceLine_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_OrderId",
                table: "Invoice",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_InvoiceId",
                table: "InvoiceLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceId",
                table: "Payment",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLine");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.AddColumn<string>(
                name: "LicImageUrl",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
