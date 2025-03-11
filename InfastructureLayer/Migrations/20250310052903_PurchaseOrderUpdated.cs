using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseOrderUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bill_PurchaseOrderId",
                table: "Bill");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "PaymentVoucher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "GoodsReceivedNote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PurchaseOrderId",
                table: "Bill",
                column: "PurchaseOrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bill_PurchaseOrderId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "PaymentVoucher");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "GoodsReceivedNote");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PurchaseOrderId",
                table: "Bill",
                column: "PurchaseOrderId");
        }
    }
}
