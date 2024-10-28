﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UTB.Restaurace.Infrastructure.Database;

#nullable disable

namespace UTB.Restaurace.Infrastructure.Migrations
{
    [DbContext(typeof(RestauraceDbContext))]
    [Migration("20241028180215_mysql_1.0.1_seeding_meals")]
    partial class mysql_101_seeding_meals
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("UTB.Restaurace.Domain.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Category")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("longtext");

                    b.Property<int>("MealId")
                        .HasMaxLength(70)
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Meal");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Available = true,
                            Category = "snídaně",
                            Description = "Křupavý kuřecí řízek podávaný s jemnou bylinkovou omáčkou a čerstvým salátem.",
                            ImageSrc = "/img/kureci_rizek.jpg",
                            MealId = 0,
                            Name = "Kuřecí řízek v bylinkové omáčce",
                            Price = 165.0
                        },
                        new
                        {
                            Id = 2,
                            Available = false,
                            Category = "snídaně",
                            Description = "Šťavnatý flank steak, grilovaný na střední propečení, podávaný s bylinkovým máslem.",
                            ImageSrc = "/img/flank_steak.jpg",
                            MealId = 0,
                            Name = "Flank Steak",
                            Price = 250.0
                        },
                        new
                        {
                            Id = 3,
                            Available = true,
                            Category = "hlavní jídlo",
                            Description = "Tradiční české jídlo s pečeným vepřovým masem, knedlíky a zelím.",
                            ImageSrc = "/img/vepro_knedlo_zelo.jpg",
                            MealId = 0,
                            Name = "Vepřové s knedlíkem a zelím",
                            Price = 180.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
