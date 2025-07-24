using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedIncrementsv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "UnitCost",
                table: "ProductStockInLogLines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UnitCost",
                table: "ProductPullOutLogLines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb2212d5-f86c-4b23-a1e0-f425a28ae9bf", "AQAAAAIAAYagAAAAELoNvBeFBXimR9RhFB0QjhWVWat5CgBGrmAKWsNuBuDlDCp26cyCAOMPwnxeQTSs2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65067cca-2b20-4058-b69e-0b46da3582c0", "AQAAAAIAAYagAAAAEEI6qFHHqEeKah5X/yEwkFKPC3G6YpB7k3wjyueDK06Vv8OOfgCWjALG4Ek60j4HIw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "620ef739-df50-40d2-be11-8182dd5c7e6c", "AQAAAAIAAYagAAAAEC0knRAJ28P1sDDej/JC2+CmABNh9QR3A1aPb5fiazcIgw8Euu/r2Z+yJRqXkFmINQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f24e5b31-917c-4d28-b547-b6c3cbfe0152", "AQAAAAIAAYagAAAAEIrfcEy8MYKHIsgqkn4dn1ZOVpu34Wlm3jrPjjyIDvNSsOwKcEpDojQ5YpuJLCNFCQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "ProductStockInLogLines");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "ProductPullOutLogLines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a50087da-5aac-4f79-ace9-c43ba25b7551", "AQAAAAIAAYagAAAAEEFGvNBVEuGtoI8yLu4y3XNB+Wn8ntX+ReokftVLl3ZoVo3ylcdnev9m5fnPG0hWmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3032a03e-7694-4e38-b90e-4d74fdde4cb1", "AQAAAAIAAYagAAAAECcy0oj5oRc541ORuuP9GFGbCM6jn2JQFHQHgCkTSvs5oQnJ9R96z0tfURNGWsJpog==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db00081e-fe05-4dbf-b3d1-7b8b9f73eaa0", "AQAAAAIAAYagAAAAEKI1WI65vKHFLdTQuzJZtqPU4VrnqM+7MzS70algeUnyae8Z8+GccSO7PxDE77TbBg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0e1666e-8bad-4e50-9727-0a28c1ae7071", "AQAAAAIAAYagAAAAELl1wBvVSPBhtixWrtZmm004gqtbnsVMwRexwhN9Jm/hItkDOOR6xisgvVd2gVWrxA==" });
        }
    }
}
