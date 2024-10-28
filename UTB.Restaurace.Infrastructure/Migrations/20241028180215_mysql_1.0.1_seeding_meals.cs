using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Restaurace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_101_seeding_meals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meal",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldMaxLength: 70)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Meal",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Meal",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Meal",
                type: "int",
                maxLength: 70,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Meal",
                columns: new[] { "Id", "Available", "Category", "Description", "ImageSrc", "MealId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, "snídaně", "Křupavý kuřecí řízek podávaný s jemnou bylinkovou omáčkou a čerstvým salátem.", "/img/kureci_rizek.jpg", 0, "Kuřecí řízek v bylinkové omáčce", 165.0 },
                    { 2, false, "snídaně", "Šťavnatý flank steak, grilovaný na střední propečení, podávaný s bylinkovým máslem.", "/img/flank_steak.jpg", 0, "Flank Steak", 250.0 },
                    { 3, true, "hlavní jídlo", "Tradiční české jídlo s pečeným vepřovým masem, knedlíky a zelím.", "/img/vepro_knedlo_zelo.jpg", 0, "Vepřové s knedlíkem a zelím", 180.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Meal");

            migrationBuilder.UpdateData(
                table: "Meal",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meal",
                type: "varchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
