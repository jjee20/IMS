using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class Add_Attendance_IsHalfDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHalfDay",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHalfDay",
                table: "Attendances");
        }
    }
}
