using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedIncrements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ProjectLines");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "ProjectLines");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "ProjectLines");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "ProjectLines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DiscountAmount",
                table: "ProjectLines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SubTotal",
                table: "ProjectLines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }
    }
}
