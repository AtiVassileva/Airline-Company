using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineCompany.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRedundantStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightStatus",
                schema: "21180083",
                table: "Flights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightStatus",
                schema: "21180083",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
