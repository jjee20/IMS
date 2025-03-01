using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class addTaskRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskRoles",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskRoles",
                table: "AspNetUsers");
        }
    }
}
