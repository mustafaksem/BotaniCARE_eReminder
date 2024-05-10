using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eReminderServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Plants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Gardeners",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Plants_AppUserId",
                table: "Plants",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardeners_AppUserId",
                table: "Gardeners",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardeners_Users_AppUserId",
                table: "Gardeners",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Users_AppUserId",
                table: "Plants",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardeners_Users_AppUserId",
                table: "Gardeners");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Users_AppUserId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_AppUserId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Gardeners_AppUserId",
                table: "Gardeners");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Gardeners");
        }
    }
}
