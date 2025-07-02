using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorNotes.Migrations
{
    /// <inheritdoc />
    public partial class changedNameOfNameToTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Notes",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Notes",
                newName: "Name");
        }
    }
}
