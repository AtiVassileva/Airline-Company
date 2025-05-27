using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineCompany.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FlightSeatAvailabilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SeatAvailabilityId",
                schema: "21180083",
                table: "Flights",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FlightSeatAvailabilities",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EconomySeatsLeft = table.Column<int>(type: "int", nullable: false),
                    BusinessSeatsLeft = table.Column<int>(type: "int", nullable: false),
                    FirstClassSeatsLeft = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSeatAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSeatAvailabilities_Flights_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "21180083",
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeatAvailabilities_FlightId",
                schema: "21180083",
                table: "FlightSeatAvailabilities",
                column: "FlightId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightSeatAvailabilities",
                schema: "21180083");

            migrationBuilder.DropColumn(
                name: "SeatAvailabilityId",
                schema: "21180083",
                table: "Flights");
        }
    }
}
