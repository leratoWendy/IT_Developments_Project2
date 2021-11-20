using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PictureShare.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hoto_id",
                table: "photos",
                newName: "photo_id");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_photos_user_id",
                table: "photos",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_photos_user_user_id",
                table: "photos",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photos_user_user_id",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "IX_photos_user_id",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "photos");

            migrationBuilder.RenameColumn(
                name: "photo_id",
                table: "photos",
                newName: "hoto_id");
        }
    }
}
