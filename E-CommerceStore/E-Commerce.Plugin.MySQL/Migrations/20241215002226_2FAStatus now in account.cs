﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Plugin.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class _2FAStatusnowinaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status2FA",
                table: "Accounts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status2FA",
                table: "Accounts");
        }
    }
}
