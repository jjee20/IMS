using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class Update_Shipment_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_ShipmentType_ShipmentTypeId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Warehouse_WarehouseId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_SalesOrderId",
                table: "Shipment");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Shipment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentTypeId",
                table: "Shipment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_SalesOrderId",
                table: "Shipment",
                column: "SalesOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_ShipmentType_ShipmentTypeId",
                table: "Shipment",
                column: "ShipmentTypeId",
                principalTable: "ShipmentType",
                principalColumn: "ShipmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Warehouse_WarehouseId",
                table: "Shipment",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_ShipmentType_ShipmentTypeId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Warehouse_WarehouseId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_SalesOrderId",
                table: "Shipment");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Shipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentTypeId",
                table: "Shipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_SalesOrderId",
                table: "Shipment",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_ShipmentType_ShipmentTypeId",
                table: "Shipment",
                column: "ShipmentTypeId",
                principalTable: "ShipmentType",
                principalColumn: "ShipmentTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Warehouse_WarehouseId",
                table: "Shipment",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
