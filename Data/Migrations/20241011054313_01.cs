using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    AirlineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.AirlineID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pwd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    AirportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.AirportID);
                    table.ForeignKey(
                        name: "FK_Airport_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID");
                });

            migrationBuilder.CreateTable(
                name: "ArrivalInfo",
                columns: table => new
                {
                    ArrivalInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportID = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivalInfo", x => x.ArrivalInfoID);
                    table.ForeignKey(
                        name: "FK_ArrivalInfo_Airport_AirportID",
                        column: x => x.AirportID,
                        principalTable: "Airport",
                        principalColumn: "AirportID");
                });

            migrationBuilder.CreateTable(
                name: "DepartureInfo",
                columns: table => new
                {
                    DepartureInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportID = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartureInfo", x => x.DepartureInfoID);
                    table.ForeignKey(
                        name: "FK_DepartureInfo_Airport_AirportID",
                        column: x => x.AirportID,
                        principalTable: "Airport",
                        principalColumn: "AirportID");
                });

            migrationBuilder.CreateTable(
                name: "Lounge",
                columns: table => new
                {
                    LoungeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirportID = table.Column<int>(type: "int", nullable: true),
                    AirlineID = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lounge", x => x.LoungeID);
                    table.ForeignKey(
                        name: "FK_Lounge_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID");
                    table.ForeignKey(
                        name: "FK_Lounge_Airport_AirportID",
                        column: x => x.AirportID,
                        principalTable: "Airport",
                        principalColumn: "AirportID");
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirlineID = table.Column<int>(type: "int", nullable: true),
                    DepartureInfoID = table.Column<int>(type: "int", nullable: true),
                    ArrivalInfoID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AirportID = table.Column<int>(type: "int", nullable: true),
                    AirportID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightID);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "Airline",
                        principalColumn: "AirlineID");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_AirportID",
                        column: x => x.AirportID,
                        principalTable: "Airport",
                        principalColumn: "AirportID");
                    table.ForeignKey(
                        name: "FK_Flight_Airport_AirportID1",
                        column: x => x.AirportID1,
                        principalTable: "Airport",
                        principalColumn: "AirportID");
                    table.ForeignKey(
                        name: "FK_Flight_ArrivalInfo_ArrivalInfoID",
                        column: x => x.ArrivalInfoID,
                        principalTable: "ArrivalInfo",
                        principalColumn: "ArrivalInfoID");
                    table.ForeignKey(
                        name: "FK_Flight_DepartureInfo_DepartureInfoID",
                        column: x => x.DepartureInfoID,
                        principalTable: "DepartureInfo",
                        principalColumn: "DepartureInfoID");
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightID = table.Column<int>(type: "int", nullable: true),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatID);
                    table.ForeignKey(
                        name: "FK_Seat_Flight_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flight",
                        principalColumn: "FlightID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    FlightID = table.Column<int>(type: "int", nullable: true),
                    SeatID = table.Column<int>(type: "int", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Flight_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flight",
                        principalColumn: "FlightID");
                    table.ForeignKey(
                        name: "FK_Booking_Seat_SeatID",
                        column: x => x.SeatID,
                        principalTable: "Seat",
                        principalColumn: "SeatID");
                    table.ForeignKey(
                        name: "FK_Booking_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CityID",
                table: "Airport",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalInfo_AirportID",
                table: "ArrivalInfo",
                column: "AirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FlightID",
                table: "Booking",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SeatID",
                table: "Booking",
                column: "SeatID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserID",
                table: "Booking",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartureInfo_AirportID",
                table: "DepartureInfo",
                column: "AirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineID",
                table: "Flight",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportID",
                table: "Flight",
                column: "AirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportID1",
                table: "Flight",
                column: "AirportID1");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ArrivalInfoID",
                table: "Flight",
                column: "ArrivalInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureInfoID",
                table: "Flight",
                column: "DepartureInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Lounge_AirlineID",
                table: "Lounge",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Lounge_AirportID",
                table: "Lounge",
                column: "AirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_FlightID",
                table: "Seat",
                column: "FlightID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Lounge");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropTable(
                name: "ArrivalInfo");

            migrationBuilder.DropTable(
                name: "DepartureInfo");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
