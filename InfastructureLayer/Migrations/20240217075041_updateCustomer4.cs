using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateCustomer4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Regions",
                table: "Customer",
                newName: "RegionCode");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Customer",
                newName: "ProvinceCode");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customer",
                newName: "CityCode");

            migrationBuilder.RenameColumn(
                name: "Barangay",
                table: "Customer",
                newName: "BarangayCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegionCode",
                table: "Customer",
                newName: "Regions");

            migrationBuilder.RenameColumn(
                name: "ProvinceCode",
                table: "Customer",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "CityCode",
                table: "Customer",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "BarangayCode",
                table: "Customer",
                newName: "Barangay");
        }
    }
}
