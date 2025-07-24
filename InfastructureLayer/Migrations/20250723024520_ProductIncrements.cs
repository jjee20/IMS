using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class ProductIncrements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductIncrements",
                columns: table => new
                {
                    ProductIncrementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Increment = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIncrements", x => x.ProductIncrementId);
                    table.ForeignKey(
                        name: "FK_ProductIncrements_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03e33163-a99b-4d44-9139-7b08a6e4260f", "AQAAAAIAAYagAAAAEE6tq6EgLpnRPySSEVcmn6OhObNF/u6XBdKDELDNNwI6H1pRUDRdhemMo0jbOPFMFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0fc24cca-4d49-4562-8dea-e9567c3840bc", "AQAAAAIAAYagAAAAEDju0NMsOf60p5kxQzMoyqEeDuAxtLPZv2tomJ4CueMGhP1PLZoKEd/Qslg6tPEbYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "995d59ab-c8b3-4454-ad15-312ea045322f", "AQAAAAIAAYagAAAAEBBpbP0heQLFB88MYpquSGVlQw6Z1uUiren99TWgEZBu4ddhcxKxJ6q0t8mqTCnYvw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6281b0d9-e4c7-4635-b0f2-668042512d07", "AQAAAAIAAYagAAAAENfBdcnuyz6ipLqFcQbbolBXNiO9/vdO33adxAzBjzSiJP1+I9RhYOUiPpbKK/EorA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductIncrements_ProductId",
                table: "ProductIncrements",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductIncrements");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ba1b0f2-1ba5-44e8-a321-ce538e8acc3c", "AQAAAAIAAYagAAAAEGoqXxOONtdWWu79cXMwdblV1R4uHBx+ZG86y7FMzHo72IWEIYoN8voq2NHMmpzh6g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c47f77ac-c4f6-4d18-a0f0-00914e993bfc", "AQAAAAIAAYagAAAAEBRVfvsL8xP5erHsC/tPIsqF+N8PYXlQ5n82YBS19CCY4ZS4ljFQTo4qB631J+atLw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "24a418d5-d4fc-40a9-9ad3-980e91f2da5b", "AQAAAAIAAYagAAAAEN2fo4QaTcD7pZ5fH8mODdAfDOFDFHiuWuqkB+xD/qgsFlKG5ZH7HM/QsxOE322T9Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1238b037-31e2-4f0a-8de1-e49fdccd44b5", "AQAAAAIAAYagAAAAEAfjxgmX8VwR8ThjaqqoxjVyPALCwACPSVe2cAQnEEz2UUREfMrZShQsmmNaUtqXvw==" });
        }
    }
}
