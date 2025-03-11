using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class PaymentReceive_InvoiceToSalesOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentReceive_Invoice_InvoiceId",
                table: "PaymentReceive");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_SalesOrderId",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "PaymentReceive",
                newName: "SalesOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentReceive_InvoiceId",
                table: "PaymentReceive",
                newName: "IX_PaymentReceive_SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SalesOrderId",
                table: "Invoice",
                column: "SalesOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentReceive_SalesOrder_SalesOrderId",
                table: "PaymentReceive",
                column: "SalesOrderId",
                principalTable: "SalesOrder",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentReceive_SalesOrder_SalesOrderId",
                table: "PaymentReceive");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_SalesOrderId",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "SalesOrderId",
                table: "PaymentReceive",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentReceive_SalesOrderId",
                table: "PaymentReceive",
                newName: "IX_PaymentReceive_InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SalesOrderId",
                table: "Invoice",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentReceive_Invoice_InvoiceId",
                table: "PaymentReceive",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
