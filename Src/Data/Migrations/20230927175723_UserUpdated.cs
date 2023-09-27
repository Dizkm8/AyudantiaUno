using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyundatiaUno.Src.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Users",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "PasswordSalt");
        }
    }
}
