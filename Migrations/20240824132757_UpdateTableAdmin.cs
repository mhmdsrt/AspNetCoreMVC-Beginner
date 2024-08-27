using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreProject1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Varchar(20)",
                table: "Admins",
                newName: "AdminName");

            migrationBuilder.RenameColumn(
                name: "Varchar(10)",
                table: "Admins",
                newName: "AdminPassword");

            migrationBuilder.AlterColumn<string>(
                name: "AdminName",
                table: "Admins",
                type: "Varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AdminPassword",
                table: "Admins",
                type: "Varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminPassword",
                table: "Admins",
                newName: "Varchar(10)");

            migrationBuilder.RenameColumn(
                name: "AdminName",
                table: "Admins",
                newName: "Varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Varchar(10)",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Varchar(20)",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(20)");
        }
    }
}
