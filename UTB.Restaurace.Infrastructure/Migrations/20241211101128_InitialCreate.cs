using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Restaurace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    ImageSrc = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Available = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Meal",
                columns: new[] { "Id", "Available", "Category", "Description", "ImageSrc", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, "hlavní jídlo", "Křupavý kuřecí řízek podávaný s jemnou bylinkovou omáčkou a čerstvým salátem.", "/img/chickenSchnitzel.jpg", "Kuřecí řízek v bylinkové omáčce", 165.0 },
                    { 2, false, "hlavní jídlo", "Šťavnatý flank steak, grilovaný na střední propečení, podávaný s bylinkovým máslem.", "/img/flankSteak.jpg", "Flank Steak", 250.0 },
                    { 3, true, "hlavní jídlo", "Tradiční české jídlo s pečeným vepřovým masem, knedlíky a zelím.", "/img/veproKnedloZelo.jpg", "Vepřové s knedlíkem a zelím", 180.0 },
                    { 4, true, "hlavní jídlo", "Šťavnatý hovězí burger s čerstvou zeleninou a domácí omáčkou.", "/img/burger.jpg", "Hovězí Burger", 200.0 },
                    { 5, true, "hlavní jídlo", "Italská pizza s pikantními plátky pepperoni a sýrem mozzarella.", "/img/pizza.jpg", "Pepperonni pizza", 220.0 },
                    { 6, true, "hlavní jídlo", "Oblíbený smažený sýr podávaný s hranolky/kroketami a tatarskou omáčkou.", "/img/smazenySyr.jpg", "Smažený sýr", 150.0 },
                    { 7, true, "polévka", "Krémová rajčatová polévka zdobená čerstvou bazalkou a parmazánem.", "/img/tomatoSoup.jpg", "Rajčatová polévka", 95.0 },
                    { 8, true, "nápoj", "Osvěžující nealkoholický nápoj s originální recepturou.", "/img/cocaCola.jpg", "Coca Cola", 35.0 },
                    { 9, true, "nápoj", "Populární nealkoholický nápoj s jedinečnou chutí.", "/img/pepsi.jpg", "Pepsi", 35.0 },
                    { 10, true, "nápoj", "Klasické české pivo s vyváženou chutí a jemnou hořkostí.", "/img/staropramen.jpg", "Staropramen", 45.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meal");
        }
    }
}
