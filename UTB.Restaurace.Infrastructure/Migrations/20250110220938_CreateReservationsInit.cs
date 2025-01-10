using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Restaurace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateReservationsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "ReservationDate", "Status", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 23, 9, 37, 693, DateTimeKind.Local).AddTicks(1639), "Confirmed", 460.0, 1 },
                    { 2, new DateTime(2025, 1, 12, 23, 9, 37, 693, DateTimeKind.Local).AddTicks(1697), "Pending", 450.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "ReserveMeal",
                columns: new[] { "Id", "Amount", "MealId", "Price", "ReservationID" },
                values: new object[,]
                {
                    { 1, 2, 1, 330.0, 1 },
                    { 2, 1, 5, 220.0, 1 },
                    { 3, 1, 2, 250.0, 2 },
                    { 4, 2, 6, 300.0, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReserveMeal",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReserveMeal",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReserveMeal",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReserveMeal",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
