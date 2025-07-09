using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedThinkEE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReviewTopics",
                newName: "ReviewTopicId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Questions",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PerformanceReports",
                newName: "PerformanceReportId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExamTopics",
                newName: "ExamTopicId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exams",
                newName: "ExamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExamResults",
                newName: "ExamResultId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExamFormats",
                newName: "ExamFormatId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Choices",
                newName: "ChoiceId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5124e9e6-dca1-4fa9-a7b8-7f33b9030c24", "AQAAAAIAAYagAAAAENfP67ADtO1AjWeSecictY24LqJxwLji7fBTScLQWG5ZeOiwo3EEZR+YvhaFXVUDqw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d55731c-4a27-4379-9f94-3a58ccc2ee0d", "AQAAAAIAAYagAAAAEECBXFWZZePksJmpe5tD+kTeEjRfnk2rdXywYU4GDlyCQ7eM9ua0l1qG+BgmLciGaA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "226e4e59-9770-48c5-8215-e17f3ba8fa8b", "AQAAAAIAAYagAAAAELBa2jcatbdrJKUokNsV25rpmj4HlqH5xtuAiDpYKskQSlJ0BQRI/mhCOYhF/Fj64Q==" });

            migrationBuilder.InsertData(
                table: "ExamFormats",
                columns: new[] { "ExamFormatId", "DefaultDurationMinutes", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 240, "Simulate full exam with time limit", "Mock Board" },
                    { 2, 120, "ExamFormatIdentify strengths and weaknesses", "Diagnostic Test" },
                    { 3, 60, "Short topic-based drills or quizzes", "Drill/Quiz" },
                    { 4, 90, "Weekly time-constrained exams", "Weekly Time-Bound" }
                });

            migrationBuilder.InsertData(
                table: "ReviewTopics",
                columns: new[] { "ReviewTopicId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "REE", "Registered Electrical Engineer" },
                    { 2, "RME", "Registered Master Electrician" }
                });

            migrationBuilder.InsertData(
                table: "ExamTopics",
                columns: new[] { "ExamTopicId", "Category", "Name", "ReviewTopicId" },
                values: new object[,]
                {
                    { 1, "Mathematics", "Algebra", 1 },
                    { 2, "Mathematics", "Trigonometry", 1 },
                    { 3, "Mathematics", "Differential and Integral Calculus", 1 },
                    { 4, "Mathematics", "Complex Numbers", 1 },
                    { 5, "Mathematics", "Probability and Statistics", 1 },
                    { 6, "Mathematics", "Differential Equations", 1 },
                    { 7, "Mathematics", "Laplace Transform and Fourier Series", 1 },
                    { 8, "Mathematics", "Matrix Algebra", 1 },
                    { 9, "Mathematics", "Numerical Methods", 1 },
                    { 10, "Engineering Sciences", "Engineering Mechanics", 1 },
                    { 11, "Engineering Sciences", "Strength of Materials", 1 },
                    { 12, "Engineering Sciences", "Thermodynamics", 1 },
                    { 13, "Engineering Sciences", "FluExamTopicId Mechanics", 1 },
                    { 14, "Engineering Sciences", "Chemistry and Physics", 1 },
                    { 15, "Engineering Sciences", "Computer Fundamentals and Programming", 1 },
                    { 16, "Electrical Circuits and Devices", "DC and AC Circuits", 1 },
                    { 17, "Electrical Circuits and Devices", "Network Theorems", 1 },
                    { 18, "Electrical Circuits and Devices", "Resonance", 1 },
                    { 19, "Electrical Circuits and Devices", "Transformers", 1 },
                    { 20, "Electrical Circuits and Devices", "Motors and Generators", 1 },
                    { 21, "Electronics", "Semiconductor Devices", 1 },
                    { 22, "Electronics", "Amplifiers", 1 },
                    { 23, "Electronics", "Oscillators", 1 },
                    { 24, "Electronics", "Operational Amplifiers", 1 },
                    { 25, "Electronics", "Digital Electronics", 1 },
                    { 26, "Electronics", "Communication Basics", 1 },
                    { 27, "Power Systems", "Power Generation", 1 },
                    { 28, "Power Systems", "Power Transmission and Distribution", 1 },
                    { 29, "Power Systems", "Load Flow and Short Circuit Analysis", 1 },
                    { 30, "Power Systems", "Protective Relays and Circuit Breakers", 1 },
                    { 31, "Power Systems", "Substation Design", 1 },
                    { 32, "Electrical Machines", "Synchronous Machines", 1 },
                    { 33, "Electrical Machines", "Induction Motors", 1 },
                    { 34, "Electrical Machines", "Transformers", 1 },
                    { 35, "Electrical Machines", "DC Machines", 1 },
                    { 36, "Electrical Machines", "Motor Control and Starting", 1 },
                    { 37, "Control Systems", "Feedback and Control Theory", 1 },
                    { 38, "Control Systems", "Block Diagrams", 1 },
                    { 39, "Control Systems", "Stability Analysis", 1 },
                    { 40, "Control Systems", "Bode Plots and Root Locus", 1 },
                    { 41, "Instrumentation and Measurement", "Electrical Measuring Instruments", 1 },
                    { 42, "Instrumentation and Measurement", "Transducers", 1 },
                    { 43, "Instrumentation and Measurement", "Calibration", 1 },
                    { 44, "Instrumentation and Measurement", "Instrument Errors", 1 },
                    { 45, "Basic Electrical Engineering", "Ohm's Law and Power Law", 2 },
                    { 46, "Electrical Design", "Wiring Design and Estimating", 2 },
                    { 47, "Regulations", "Philippine Electrical Code", 2 },
                    { 48, "Practical Applications", "Electrical Wiring Installation", 2 },
                    { 49, "Materials and Tools", "Tools and Electrical Materials", 2 },
                    { 50, "Safety", "Safety Practices", 2 },
                    { 51, "Testing and Measurement", "Electrical Test Equipment", 2 }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "Date", "ExamFormatId", "ReviewTopicId", "Title", "Type" },
                values: new object[] { 1, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Electrical Circuits Mock Exam", "Mock Board" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "ExamId", "ExamTopicId", "Points", "Text" },
                values: new object[,]
                {
                    { 1, 1, 16, 1, "What is the unit of resistance?" },
                    { 2, 1, 16, 1, "What law states that V = IR?" }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "ChoiceId", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, true, 1, "Ohm" },
                    { 2, false, 1, "Volt" },
                    { 3, false, 1, "Watt" },
                    { 4, false, 1, "Ampere" },
                    { 5, true, 2, "Ohm's Law" },
                    { 6, false, 2, "Kirchhoff's Law" },
                    { 7, false, 2, "Faraday's Law" },
                    { 8, false, 2, "Coulomb's Law" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExamFormats",
                keyColumn: "ExamFormatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExamFormats",
                keyColumn: "ExamFormatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExamFormats",
                keyColumn: "ExamFormatId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReviewTopics",
                keyColumn: "ReviewTopicId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExamTopics",
                keyColumn: "ExamTopicId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exams",
                keyColumn: "ExamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExamFormats",
                keyColumn: "ExamFormatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReviewTopics",
                keyColumn: "ReviewTopicId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "ReviewTopicId",
                table: "ReviewTopics",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PerformanceReportId",
                table: "PerformanceReports",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExamTopicId",
                table: "ExamTopics",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "Exams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExamResultId",
                table: "ExamResults",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExamFormatId",
                table: "ExamFormats",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ChoiceId",
                table: "Choices",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587A4D5B-33EB-469C-ADE6-EC9F95C651AD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a828565-e3bf-4968-9589-d17d77725d54", "AQAAAAIAAYagAAAAEJ9SUK2UBa8RGz5+7kBVln2LwU4uiXZmXIxr+/z7tmr3EX+z79tB4f7M0Ke63EZQmw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6628DE62-AF21-4389-B612-623A1A17637C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "773ddb02-3ea7-406a-b6ce-42f296cb1d41", "AQAAAAIAAYagAAAAECWxr5DXl7/3G7uJQUU1B6gv6inQx2qSBvY0DnETpHowY/nFmCecOTkc03P2orn1pA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB38CC93-2B1E-4444-9A48-396E4C28E190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ec6c01a-91c0-4250-ac26-c48a662bd451", "AQAAAAIAAYagAAAAEHG3OGG/+oUf8+a2Xhck+0GVfhLVIpjiQfxJVRwcsuwGUXlmEjlZJv8uTxnlg1a1aw==" });
        }
    }
}
