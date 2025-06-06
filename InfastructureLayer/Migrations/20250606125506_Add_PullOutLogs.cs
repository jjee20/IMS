using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class Add_PullOutLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPullOutLogs",
                columns: table => new
                {
                    ProductPullOutLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductStatus = table.Column<int>(type: "int", nullable: false),
                    DeliveredBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPullOutLogs", x => x.ProductPullOutLogId);
                });

            migrationBuilder.CreateTable(
                name: "ProductPullOutLogLines",
                columns: table => new
                {
                    ProductPullOutLogLinesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPullOutId = table.Column<int>(type: "int", nullable: false),
                    ProductPullOutLogId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPullOutLogLines", x => x.ProductPullOutLogLinesId);
                    table.ForeignKey(
                        name: "FK_ProductPullOutLogLines_ProductPullOutLogs_ProductPullOutLogId",
                        column: x => x.ProductPullOutLogId,
                        principalTable: "ProductPullOutLogs",
                        principalColumn: "ProductPullOutLogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPullOutLogLines_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "190a33ee-3945-411f-bc76-e84e521fe3c1", "AQAAAAIAAYagAAAAEGt/DTn7OsvwDfUULPkHVs0IhrftFxPpyHw4NVdgGXzjrWz4i00JFJPzUBJ8IRXzZw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1177e770-4bce-4829-abe4-2b8af26d33d9", "AQAAAAIAAYagAAAAEMYfpoiHBo586cjalRexR2cHqe5h3hpwkzXP2rS/6iMuiQG8SZPdeohBbQsG8X6otA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ecea06af-e595-4a36-8b9d-7bfb8532858b", "AQAAAAIAAYagAAAAEKtguSUxWPJsjnzUqLD+fC87ZpaY+aXLJFW7fbtrNoQNjWS9P4UhnT2a0/7vabM4ag==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPullOutLogLines_ProductId",
                table: "ProductPullOutLogLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPullOutLogLines_ProductPullOutLogId",
                table: "ProductPullOutLogLines",
                column: "ProductPullOutLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPullOutLogLines");

            migrationBuilder.DropTable(
                name: "ProductPullOutLogs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b380764-5a31-4454-b12f-f7cf065683e7", "AQAAAAIAAYagAAAAEH9N2b8nixji2h/2Zs5jZWXGBrz1G9SGLLQTdGOPU37P0l3R0C3YqLierCAma8igTA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86fc95d8-cc36-4fab-9721-e7361818fbbe", "AQAAAAIAAYagAAAAEL0wlU2LJEVd2JWk7rDnQv61+Q1VjI6l+6DGVYEPvCgcaHuiu0P+JqVzpnhdlh7VGA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e10774f7-5020-4df1-82fe-11486c46f554", "AQAAAAIAAYagAAAAEHeFFUzSbdqkZeECURr359cExbsU3ymZ0w9ftU6BknIAsALgalSzyKfFqTgBrHcWnA==" });
        }
    }
}
