using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindRooMateApi.Migrations
{
    public partial class Add_Room_To_Announcement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_RoomId",
                table: "Announcements",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Rooms_RoomId",
                table: "Announcements",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Rooms_RoomId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_RoomId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Announcements");
        }
    }
}
