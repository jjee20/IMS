using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedExamResultChoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamResultChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamResultId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ChoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResultChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResultChoices_Choices_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "Choices",
                        principalColumn: "ChoiceId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExamResultChoices_ExamResults_ExamResultId",
                        column: x => x.ExamResultId,
                        principalTable: "ExamResults",
                        principalColumn: "ExamResultId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExamResultChoices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2878BA2F-5B81-4BD3-A830-6733C6536AAF",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be6b0696-9582-46f4-adfd-d9f99041f1bd", "AQAAAAIAAYagAAAAEKpwz8TGB3UsbRxoMKW7E58taXbrQ7aLZa7n42R2dIU9AtGH7cEcwXl7YwTMpuBFZQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27cff5e2-8cf8-4b1c-ab6a-a9664d43dd51", "AQAAAAIAAYagAAAAEK326FkVgM5OY+wbjPQYDawXv/z8EG7GFNDL7oIc0tSTXdHf7T8gJM9GOwSoyKl0Qg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de7755d5-6318-4250-9d64-e2924cb72325", "AQAAAAIAAYagAAAAEDsUfDml08wMtC7y+1GZta3nhf4L3VIjYvsh6s/l+nNAYh61EfpmDE2CS+Ktj7sMvg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e2f8f0f-4b09-443c-8222-a3c571c6f655", "AQAAAAIAAYagAAAAEPBYuOZnd5/TtYrmXpXwpX9Dd6O8xKslIdTtYXxSOjNv2/gQvWDmS1JGrsBG9f0Niw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultChoices_ChoiceId",
                table: "ExamResultChoices",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultChoices_ExamResultId",
                table: "ExamResultChoices",
                column: "ExamResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultChoices_QuestionId",
                table: "ExamResultChoices",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamResultChoices");

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
    }
}
