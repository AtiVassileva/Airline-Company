using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineCompany.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedReservationsAndPassengers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_ReservationId",
                schema: "21180083",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                schema: "21180083",
                table: "Passengers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "21180083",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerId",
                schema: "21180083",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                schema: "21180083",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ReservationId",
                schema: "21180083",
                table: "Passengers",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                schema: "21180083",
                table: "Reservations",
                column: "UserId",
                principalSchema: "21180083",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                schema: "21180083",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                schema: "21180083",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_ReservationId",
                schema: "21180083",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                schema: "21180083",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "21180083",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                schema: "21180083",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ReservationId",
                schema: "21180083",
                table: "Passengers",
                column: "ReservationId");
        }
    }
}
