using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class PullOutLogs_Add_Project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductPullOutLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ProductPullOutLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8211cb92-0b9a-4195-9d37-db25403a1afe", "AQAAAAIAAYagAAAAEPFdQU6wAdeTXofBPQHTDGr3oqCCiavoJNJVPSibQS/i8JERij71n0j3vwgKeW/g8A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2ebb269-72a1-49b5-8a49-88088336fb34", "AQAAAAIAAYagAAAAENNMAfsCEVRpLQdjyHC1NZ+NcAY+LJxZTcml2kNldn6hPgQrLJ1YfH2rh7BfRSLOSw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c728b0f-da4f-460f-9d1f-e9dc7146871d", "AQAAAAIAAYagAAAAENUX0vUWuhexh6mLaetGq06T3lmG5+Xr1ffnIUWSJQDflPf0ZJu2lrbS2HkrGarxvw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPullOutLogs_ProductId",
                table: "ProductPullOutLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPullOutLogs_ProjectId",
                table: "ProductPullOutLogs",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPullOutLogs_Product_ProductId",
                table: "ProductPullOutLogs",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPullOutLogs_Projects_ProjectId",
                table: "ProductPullOutLogs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPullOutLogs_Product_ProductId",
                table: "ProductPullOutLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPullOutLogs_Projects_ProjectId",
                table: "ProductPullOutLogs");

            migrationBuilder.DropIndex(
                name: "IX_ProductPullOutLogs_ProductId",
                table: "ProductPullOutLogs");

            migrationBuilder.DropIndex(
                name: "IX_ProductPullOutLogs_ProjectId",
                table: "ProductPullOutLogs");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductPullOutLogs");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProductPullOutLogs");

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
        }
    }
}
