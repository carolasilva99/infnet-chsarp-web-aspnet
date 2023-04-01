using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameFieldAnoAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Books",
                newName: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Books",
                newName: "Year");
        }
    }
}
