using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Plugin.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoFactorID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TwoFactorID",
                table: "Accounts",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoFactorID",
                table: "Accounts");
        }
    }
}
