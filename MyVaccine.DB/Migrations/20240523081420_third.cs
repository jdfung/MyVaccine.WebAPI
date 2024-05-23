using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVaccine.DB.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "adminPassword",
                table: "admins",
                newName: "adminUserName");

            migrationBuilder.RenameColumn(
                name: "adminName",
                table: "admins",
                newName: "adminPasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "adminUserName",
                table: "admins",
                newName: "adminPassword");

            migrationBuilder.RenameColumn(
                name: "adminPasswordHash",
                table: "admins",
                newName: "adminName");
        }
    }
}
