using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class SalesOrderLineAddProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLine_Product_ProductId",
                table: "SalesOrderLine");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SalesOrderLine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "SalesOrderLine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLine_Product_ProductId",
                table: "SalesOrderLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderLine_Product_ProductId",
                table: "SalesOrderLine");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "SalesOrderLine");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "SalesOrderLine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderLine_Product_ProductId",
                table: "SalesOrderLine",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
