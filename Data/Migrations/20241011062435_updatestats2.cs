using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatestats2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_AirportID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_AirportID1",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_AirportID",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_AirportID1",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "AirportID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "AirportID1",
                table: "Flight");

            migrationBuilder.CreateTable(
                name: "AirportStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalFlights = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportStatistics", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportStatistics");

            migrationBuilder.AddColumn<int>(
                name: "AirportID",
                table: "Flight",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AirportID1",
                table: "Flight",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportID",
                table: "Flight",
                column: "AirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportID1",
                table: "Flight",
                column: "AirportID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_AirportID",
                table: "Flight",
                column: "AirportID",
                principalTable: "Airport",
                principalColumn: "AirportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_AirportID1",
                table: "Flight",
                column: "AirportID1",
                principalTable: "Airport",
                principalColumn: "AirportID");
        }
    }
}
