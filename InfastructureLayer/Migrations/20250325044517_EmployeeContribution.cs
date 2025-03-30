using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeContribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeContribution",
                columns: table => new
                {
                    EmployeeContributionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SSS = table.Column<double>(type: "float", nullable: false),
                    SSSWISP = table.Column<double>(type: "float", nullable: false),
                    PagIbig = table.Column<double>(type: "float", nullable: false),
                    PhilHealth = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContribution", x => x.EmployeeContributionId);
                    table.ForeignKey(
                        name: "FK_EmployeeContribution_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContribution_EmployeeId",
                table: "EmployeeContribution",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContribution");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Product");
        }
    }
}
