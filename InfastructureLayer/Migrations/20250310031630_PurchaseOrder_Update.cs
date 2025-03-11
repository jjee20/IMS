using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseOrder_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_GoodsReceivedNote_GoodsReceivedNoteId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentVoucher_Bill_BillId",
                table: "PaymentVoucher");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "PaymentVoucher",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentVoucher_BillId",
                table: "PaymentVoucher",
                newName: "IX_PaymentVoucher_PurchaseOrderId");

            migrationBuilder.RenameColumn(
                name: "GoodsReceivedNoteId",
                table: "Bill",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_GoodsReceivedNoteId",
                table: "Bill",
                newName: "IX_Bill_PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_PurchaseOrder_PurchaseOrderId",
                table: "Bill",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentVoucher_PurchaseOrder_PurchaseOrderId",
                table: "PaymentVoucher",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_PurchaseOrder_PurchaseOrderId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentVoucher_PurchaseOrder_PurchaseOrderId",
                table: "PaymentVoucher");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "PaymentVoucher",
                newName: "BillId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentVoucher_PurchaseOrderId",
                table: "PaymentVoucher",
                newName: "IX_PaymentVoucher_BillId");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "Bill",
                newName: "GoodsReceivedNoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_PurchaseOrderId",
                table: "Bill",
                newName: "IX_Bill_GoodsReceivedNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_GoodsReceivedNote_GoodsReceivedNoteId",
                table: "Bill",
                column: "GoodsReceivedNoteId",
                principalTable: "GoodsReceivedNote",
                principalColumn: "GoodsReceivedNoteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentVoucher_Bill_BillId",
                table: "PaymentVoucher",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
