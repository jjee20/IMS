using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class Update_Invoice_ShipmentIdToSalesOrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Shipment_ShipmentId",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "Invoice",
                newName: "SalesOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ShipmentId",
                table: "Invoice",
                newName: "IX_Invoice_SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_SalesOrder_SalesOrderId",
                table: "Invoice",
                column: "SalesOrderId",
                principalTable: "SalesOrder",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_SalesOrder_SalesOrderId",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "SalesOrderId",
                table: "Invoice",
                newName: "ShipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_SalesOrderId",
                table: "Invoice",
                newName: "IX_Invoice_ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Shipment_ShipmentId",
                table: "Invoice",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
