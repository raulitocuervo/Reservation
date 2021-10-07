using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation.Shared.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Contacts");

            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Ranking",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Reservations");

            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Ranking",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
