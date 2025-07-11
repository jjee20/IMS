using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class includeTaskRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "TaskRoles" },
                values: new object[] { "025c81bc-0ec9-46e7-963f-485356f19d2a", "AQAAAAIAAYagAAAAEOAJ0NO3dzVM5kPZ8Pd2ZGbcxqLxiZDqBjP5t4SDbyPXdD6Zu1KZgGtJZ9YAuXLaLA==", "[0,1,2,3,4]" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "TaskRoles" },
                values: new object[] { "dc61454d-79ef-4b9f-b630-760025ec6cd1", "AQAAAAIAAYagAAAAEG6wb7538hgWjBq1OinKG17xnVpysLii54tfIfayu3UzFhczCR8zHvJ4f2QQM5wdMQ==", "[0,1,2,3]" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "TaskRoles" },
                values: new object[] { "c5b1deb7-c62a-4b92-8523-ddbc3fc89e72", "AQAAAAIAAYagAAAAEFre/zIhRJiaejz5Ns/1X5SvTdZcvda8ZFKX3Q1/HvyaTARiac1MBTZLyfmc9XaF3Q==", "[0,1,2,3]" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaskRoles", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2878BA2F-5B81-4BD3-A830-6733C6536AAF", 0, "1b3fabd6-4666-4222-a624-0f108af88fe5", 2, "guest@user.com", true, false, null, "GUEST@USER.COM", "GUEST", "AQAAAAIAAYagAAAAEHiUzBAOrIzw97ue3ZQOAhr4i7hl0W1m41/5gS+YwDYu0euzLI8QztWvlqyHTIrvHQ==", null, false, "", "[3]", false, "guest" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "TaskRoles" },
                values: new object[] { "5124e9e6-dca1-4fa9-a7b8-7f33b9030c24", "AQAAAAIAAYagAAAAENfP67ADtO1AjWeSecictY24LqJxwLji7fBTScLQWG5ZeOiwo3EEZR+YvhaFXVUDqw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "TaskRoles" },
                values: new object[] { "9d55731c-4a27-4379-9f94-3a58ccc2ee0d", "AQAAAAIAAYagAAAAEECBXFWZZePksJmpe5tD+kTeEjRfnk2rdXywYU4GDlyCQ7eM9ua0l1qG+BgmLciGaA==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "TaskRoles" },
                values: new object[] { "226e4e59-9770-48c5-8215-e17f3ba8fa8b", "AQAAAAIAAYagAAAAELBa2jcatbdrJKUokNsV25rpmj4HlqH5xtuAiDpYKskQSlJ0BQRI/mhCOYhF/Fj64Q==", null });
        }
    }
}
