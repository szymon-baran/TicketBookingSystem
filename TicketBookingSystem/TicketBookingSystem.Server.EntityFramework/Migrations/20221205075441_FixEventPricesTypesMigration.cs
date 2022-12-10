using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBookingSystem.Server.EntityFramework.Migrations
{
    public partial class FixEventPricesTypesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReducedDiscountPercent",
                table: "Events");

            migrationBuilder.AlterColumn<double>(
                name: "StandingTicketPrice",
                table: "Events",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "SittingTicketPrice",
                table: "Events",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "ReducedDiscount",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReducedDiscount",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "StandingTicketPrice",
                table: "Events",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "SittingTicketPrice",
                table: "Events",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "ReducedDiscountPercent",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
