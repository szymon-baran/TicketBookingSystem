using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBookingSystem.Server.EntityFramework.Migrations
{
    public partial class TicketOwnerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BuyerId1",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerFirstName",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerLastName",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OwnerPESEL",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BuyerId1",
                table: "Tickets",
                column: "BuyerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_BuyerId1",
                table: "Tickets",
                column: "BuyerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_BuyerId1",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BuyerId1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BuyerId1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OwnerFirstName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OwnerLastName",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OwnerPESEL",
                table: "Tickets");
        }
    }
}
