using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineCompany.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "21180083");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "21180083");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "21180083");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "21180083");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "21180083");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "21180083");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "21180083");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "21180083");

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LuggageTypes",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false),
                    MaxHeight = table.Column<int>(type: "int", nullable: false),
                    MaxDepth = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuggageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plane",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    EconomySeats = table.Column<int>(type: "int", nullable: false),
                    BusinessSeats = table.Column<int>(type: "int", nullable: false),
                    FirstClassSeats = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightStatus = table.Column<int>(type: "int", nullable: false),
                    PlaneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArrivalDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Destinations_ArrivalDestinationId",
                        column: x => x.ArrivalDestinationId,
                        principalSchema: "21180083",
                        principalTable: "Destinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Destinations_DepartureDestinationId",
                        column: x => x.DepartureDestinationId,
                        principalSchema: "21180083",
                        principalTable: "Destinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Plane_PlaneId",
                        column: x => x.PlaneId,
                        principalSchema: "21180083",
                        principalTable: "Plane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LuggageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Flights_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "21180083",
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_LuggageTypes_LuggageId",
                        column: x => x.LuggageId,
                        principalSchema: "21180083",
                        principalTable: "LuggageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "21180083",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_TicketTypes_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "21180083",
                        principalTable: "TicketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    FlightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Flights_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "21180083",
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                schema: "21180083",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNo = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalSchema: "21180083",
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivalDestinationId",
                schema: "21180083",
                table: "Flights",
                column: "ArrivalDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureDestinationId",
                schema: "21180083",
                table: "Flights",
                column: "DepartureDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                schema: "21180083",
                table: "Flights",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ReservationId",
                schema: "21180083",
                table: "Passengers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FlightId",
                schema: "21180083",
                table: "Reservations",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LuggageId",
                schema: "21180083",
                table: "Reservations",
                column: "LuggageId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StatusId",
                schema: "21180083",
                table: "Reservations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TicketId",
                schema: "21180083",
                table: "Reservations",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightId",
                schema: "21180083",
                table: "Seats",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "Passengers",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "Seats",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "Flights",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "LuggageTypes",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "TicketTypes",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "Destinations",
                schema: "21180083");

            migrationBuilder.DropTable(
                name: "Plane",
                schema: "21180083");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "21180083",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "21180083",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "21180083",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "21180083",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "21180083",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "21180083",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "21180083",
                newName: "AspNetRoleClaims");
        }
    }
}
