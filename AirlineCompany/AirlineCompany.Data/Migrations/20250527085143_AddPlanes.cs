using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineCompany.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Plane_PlaneId",
                schema: "21180083",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plane",
                schema: "21180083",
                table: "Plane");

            migrationBuilder.RenameTable(
                name: "Plane",
                schema: "21180083",
                newName: "Planes",
                newSchema: "21180083");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                schema: "21180083",
                table: "Planes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                schema: "21180083",
                table: "Flights",
                column: "PlaneId",
                principalSchema: "21180083",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                schema: "21180083",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                schema: "21180083",
                table: "Planes");

            migrationBuilder.RenameTable(
                name: "Planes",
                schema: "21180083",
                newName: "Plane",
                newSchema: "21180083");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plane",
                schema: "21180083",
                table: "Plane",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Plane_PlaneId",
                schema: "21180083",
                table: "Flights",
                column: "PlaneId",
                principalSchema: "21180083",
                principalTable: "Plane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
