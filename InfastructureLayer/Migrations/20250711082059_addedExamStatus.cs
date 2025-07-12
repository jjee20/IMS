using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedExamStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamStatus",
                table: "ExamResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "104475e9-ec5c-4a1e-98bf-6491e3521b58", "AQAAAAIAAYagAAAAEGxGzsww47+0PlOqp3R12mQ109XSfkHFI37dYGS3Za4XEXQ5Gy+chPraaEq7GDDzZg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7865c47-c9ec-4fb2-b39f-235f3254b502", "AQAAAAIAAYagAAAAEFyIBYfvih05hp3p6uhjNUyHMeY3iOb0l6AkEwZ3bcrr1QDnBPbvjcDtE3j+1CSXXA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32504431-06ad-433c-891d-135ce07684c0", "AQAAAAIAAYagAAAAEKyY1Rr+iw42b3iohbymIHg202E+WKyesYlyGs8SwQmIXmVTk4RPfxx473KbCJcAtw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72cda1dc-9c13-4138-8575-5249d89303f9", "AQAAAAIAAYagAAAAEHsklPxyuPfCDi48rtcIOMNEHRcsax2ZdgqO4ZKqPk5GHNszcgXCoNpE3EEIWbeL9A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamStatus",
                table: "ExamResults");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b3fabd6-4666-4222-a624-0f108af88fe5", "AQAAAAIAAYagAAAAEHiUzBAOrIzw97ue3ZQOAhr4i7hl0W1m41/5gS+YwDYu0euzLI8QztWvlqyHTIrvHQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "025c81bc-0ec9-46e7-963f-485356f19d2a", "AQAAAAIAAYagAAAAEOAJ0NO3dzVM5kPZ8Pd2ZGbcxqLxiZDqBjP5t4SDbyPXdD6Zu1KZgGtJZ9YAuXLaLA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc61454d-79ef-4b9f-b630-760025ec6cd1", "AQAAAAIAAYagAAAAEG6wb7538hgWjBq1OinKG17xnVpysLii54tfIfayu3UzFhczCR8zHvJ4f2QQM5wdMQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5b1deb7-c62a-4b92-8523-ddbc3fc89e72", "AQAAAAIAAYagAAAAEFre/zIhRJiaejz5Ns/1X5SvTdZcvda8ZFKX3Q1/HvyaTARiac1MBTZLyfmc9XaF3Q==" });
        }
    }
}
