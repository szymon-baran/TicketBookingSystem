using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBookingSystem.Server.EntityFramework.Migrations
{
    public partial class EventPricesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReducedDiscountPercent",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SittingTicketPrice",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandingTicketPrice",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReducedDiscountPercent",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SittingTicketPrice",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StandingTicketPrice",
                table: "Events");
        }
    }
}
