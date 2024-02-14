using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Customer",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customer",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customer",
                newName: "Municipality");

            migrationBuilder.AddColumn<string>(
                name: "Barangay",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barangay",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Customer",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Customer",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Municipality",
                table: "Customer",
                newName: "Address");
        }
    }
}
