using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UTB.Restaurace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_102_seeding_meals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "MealId" },
                values: new object[] { "hlavní jídlo", 1 });

            migrationBuilder.UpdateData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "MealId" },
                values: new object[] { "hlavní jídlo", 2 });

            migrationBuilder.UpdateData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 3,
                column: "MealId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "MealId" },
                values: new object[] { "snídaně", 0 });

            migrationBuilder.UpdateData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "MealId" },
                values: new object[] { "snídaně", 0 });

            migrationBuilder.UpdateData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 3,
                column: "MealId",
                value: 0);
        }
    }
}
