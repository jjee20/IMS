using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedTimeInExamResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "ExamDuration",
                table: "ExamResults",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExamStartTime",
                table: "ExamResults",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "793e1fbf-e6e0-40c9-931f-604d857fad65", "AQAAAAIAAYagAAAAEDgLbyBAa5XBLlxGr3QJdNJ/+ylBTyL78W991fcEfNNu9DoHgpDURhkp5Njri5OPDA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b583369-a858-4109-b869-03b877117c5f", "AQAAAAIAAYagAAAAEEY2V4x8y2wMtldiozzMkK5WZjKCvJNwCQFQNDAA26pjGxit0z0fozpL7reJB2H9VQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "344af7f2-1983-483a-bbbe-5ceca955a2e4", "AQAAAAIAAYagAAAAEEfUBNe8Vza2rvqwci8F3WXkubX9o8n3h+JPNZDuVRrdW7b8eY3lLG4hDWgGj9BZMw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20e6866d-99b7-42ae-b190-4bf3967b0754", "AQAAAAIAAYagAAAAECx2LwucNA5ngF2jOvjqRdcBmOSHoWUEa7UBRAOoGU7bgTrCsWJIxnE3LxHTJXyNfA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamDuration",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "ExamStartTime",
                table: "ExamResults");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "607822bc-0588-449b-834e-3a1788d98af7", "AQAAAAIAAYagAAAAENf/yVswj2k9Mjt01IXytkqkdvxFEkvUQUP1lGa77kddaXeI3IaqbLCgepcjDhjt6Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "825e4117-eb3a-487b-8a6f-4f6b029c6af6", "AQAAAAIAAYagAAAAEDOXKe0Vm3Fw1RRZ+ZHcxZS+Z+WMKRV8ToPzxvUys7dS7+5XnBM+gS5Z2PhkE+gu0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c70b1ab-0b41-49e1-bf61-dd622e9ee7ff", "AQAAAAIAAYagAAAAED2tZhXWj+Dr3IQPSLKmq7XmbPN0Hw/ynN54cRUa7K2gAnmWWNRGCTeh/+sIpQfTCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8eb79ac6-ed89-434c-9cfb-e3a2dce6a524", "AQAAAAIAAYagAAAAEOMs3OUsxU0ppV53CbptE8MUQ/d9avULZILsdiAjcUDVU6pFw5HJxFfFitOz3VfpqA==" });
        }
    }
}
