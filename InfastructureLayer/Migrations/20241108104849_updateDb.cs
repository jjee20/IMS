using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNote_PurchaseOrder_PurchaseOrderId",
                table: "GoodsReceivedNote");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Vendor",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Vendor",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Vendor",
                newName: "Municipality");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Branch",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Branch",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Branch",
                newName: "Municipality");

            migrationBuilder.AddColumn<string>(
                name: "Barangay",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderId1",
                table: "GoodsReceivedNote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Barangay",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceive_InvoiceId",
                table: "PaymentReceive",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceivedNote_PurchaseOrderId1",
                table: "GoodsReceivedNote",
                column: "PurchaseOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CurrencyId",
                table: "Branch",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_GoodsReceivedNoteId",
                table: "Bill",
                column: "GoodsReceivedNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_GoodsReceivedNote_GoodsReceivedNoteId",
                table: "Bill",
                column: "GoodsReceivedNoteId",
                principalTable: "GoodsReceivedNote",
                principalColumn: "GoodsReceivedNoteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Currency_CurrencyId",
                table: "Branch",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceivedNote_PurchaseOrder_PurchaseOrderId1",
                table: "GoodsReceivedNote",
                column: "PurchaseOrderId1",
                principalTable: "PurchaseOrder",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceivedNote_Warehouse_PurchaseOrderId",
                table: "GoodsReceivedNote",
                column: "PurchaseOrderId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentReceive_Invoice_InvoiceId",
                table: "PaymentReceive",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_GoodsReceivedNote_GoodsReceivedNoteId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Currency_CurrencyId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNote_PurchaseOrder_PurchaseOrderId1",
                table: "GoodsReceivedNote");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceivedNote_Warehouse_PurchaseOrderId",
                table: "GoodsReceivedNote");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentReceive_Invoice_InvoiceId",
                table: "PaymentReceive");

            migrationBuilder.DropIndex(
                name: "IX_PaymentReceive_InvoiceId",
                table: "PaymentReceive");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceivedNote_PurchaseOrderId1",
                table: "GoodsReceivedNote");

            migrationBuilder.DropIndex(
                name: "IX_Branch_CurrencyId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Bill_GoodsReceivedNoteId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "Barangay",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId1",
                table: "GoodsReceivedNote");

            migrationBuilder.DropColumn(
                name: "Barangay",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Vendor",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Vendor",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Municipality",
                table: "Vendor",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Branch",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Branch",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Municipality",
                table: "Branch",
                newName: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceivedNote_PurchaseOrder_PurchaseOrderId",
                table: "GoodsReceivedNote",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
