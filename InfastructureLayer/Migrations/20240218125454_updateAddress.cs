using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Vendor",
                newName: "RegionCode");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Vendor",
                newName: "ProvinceCode");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Vendor",
                newName: "CityCode");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Branch",
                newName: "RegionCode");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Branch",
                newName: "ProvinceCode");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Branch",
                newName: "CityCode");

            migrationBuilder.AddColumn<string>(
                name: "BarangayCode",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BarangayCode",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CurrencyId",
                table: "Branch",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Currency_CurrencyId",
                table: "Branch",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Currency_CurrencyId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_CurrencyId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "BarangayCode",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "BarangayCode",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "RegionCode",
                table: "Vendor",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "ProvinceCode",
                table: "Vendor",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "CityCode",
                table: "Vendor",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "RegionCode",
                table: "Branch",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "ProvinceCode",
                table: "Branch",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "CityCode",
                table: "Branch",
                newName: "Address");
        }
    }
}
