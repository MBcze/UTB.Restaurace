using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UTB.Restaurace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateReservationAndReserveMeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReservationCreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    ReservationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalPrice = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReserveMeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReservationID = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveMeal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReserveMeal_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveMeal_Reservation_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveMeal_MealId",
                table: "ReserveMeal",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveMeal_ReservationID",
                table: "ReserveMeal",
                column: "ReservationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReserveMeal");

            migrationBuilder.DropTable(
                name: "Reservation");
        }
    }
}
