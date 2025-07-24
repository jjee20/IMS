using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddExamResultToExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Exams_ExamId",
                table: "ExamResults");

            migrationBuilder.DropIndex(
                name: "IX_ExamResults_ExamId",
                table: "ExamResults");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Exams");

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
                columns: new[] { "ExamResultId", "ReviewTopicId" },
                values: new object[] { null, 1 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "ExamId",
                keyValue: 1,
                columns: new[] { "ReviewTopicId", "Type" },
                values: new object[] { null, "Mock Board" });

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
    }
}
