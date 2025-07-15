using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatedExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_ExamResults_ExamResultId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ExamResultId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamResultId",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "ExamResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_ExamId",
                table: "ExamResults",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults");

            migrationBuilder.DropIndex(
                name: "IX_ExamResults_ExamId",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "ExamResults");

            migrationBuilder.AddColumn<int>(
                name: "ExamResultId",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "70dcaec4-45d7-412b-9638-89d476adf393", "AQAAAAIAAYagAAAAEDCILT9M8++tAl3GC6HIxKSIjolSANv+zXWyU4pCWD5f9KXlQ4NXb3h/zH33ncEbIQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6980e11e-f7dc-430b-9c76-d879eace7d0a", "AQAAAAIAAYagAAAAEB+zN/rTmlc6SslhaW6WfKAjrWUTCWxzakZDlfpV74EOU4TrGOL7jT6ssU1cnkDzmw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6fcf43bd-2b57-48aa-a026-df0a36556284", "AQAAAAIAAYagAAAAEHUPnsV8zXozkz5Rx6lGYAtXKrLgvfMA1mUW4+abE37kpLECGwdidPQxly2ChfxW/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c8e048b-9b5c-4533-a295-8a621527dbe0", "AQAAAAIAAYagAAAAEHP6cc/zTEEYLcw5DxqDoEn9kGe/Wf7VlpUOmyEMWqLX2ZwvwZ9mGmWmRV45BfVjsA==" });

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "ExamId",
                keyValue: 1,
                column: "ExamResultId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExamResultId",
                table: "Exams",
                column: "ExamResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_ExamResults_ExamResultId",
                table: "Exams",
                column: "ExamResultId",
                principalTable: "ExamResults",
                principalColumn: "ExamResultId");
        }
    }
}
