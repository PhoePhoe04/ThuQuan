using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThuQuan.Migrations
{
    /// <inheritdoc />
    public partial class violationupdatePenalty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "penalty",
                table: "Violations",
                newName: "Penalty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Penalty",
                table: "Violations",
                newName: "penalty");
        }
    }
}
