using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalsOnPages.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Building", "City", "Country", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, 24, "Ivano-Frankivsk", "Ukraine", 76002, "Uhornytska str." },
                    { 2, 18, "Kherson", "Ukraine", 24431, "Nezalezhnosti str." },
                    { 3, 178, "Odessa", "Ukraine", 22905, "Peremohy blr." },
                    { 4, 277, "Krakiv", "Poland", 10260, "Perelutsk str." },
                    { 5, 143, "Lodz", "Poland", 11713, "Stratvens str." }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "CoverColor", "Discriminator", "Name", "Rank", "Sex", "Sound" },
                values: new object[,]
                {
                    { 1, "Grey", "Mammal", "Wolf", "Carnivorous", "Male", "Owoo-oo-oo" },
                    { 2, "BrownBrown", "Mammal", "Bear", "Carnivorous", "Female", "Ur-r-r" },
                    { 3, "LightGrey", "Reptile", "Crocodile", "Carnivorous", "Male", "Grunt, grunt, grunt" },
                    { 4, "LightGrey", "Reptile", "Turtle", "Herbivorous", "Female", "Creek, creek, creek" },
                    { 5, "Green", "Amphibia", "Frog", "Herbivorous", "Female", "Kwa, kwa, kwa" }
                });

            migrationBuilder.InsertData(
                table: "Zoos",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Carpathian National Nature Park" },
                    { 2, 2, "The country of Enotia" },
                    { 3, 3, "Odesa Zoo" },
                    { 4, 4, "Krakow Zoo" },
                    { 5, 5, "Royal Lazenky" }
                });

            migrationBuilder.InsertData(
                table: "ZooAnimal",
                columns: new[] { "Id", "AnimalId", "ZooId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 4, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 3, 3 },
                    { 7, 5, 3 },
                    { 8, 2, 4 },
                    { 9, 3, 4 },
                    { 10, 3, 5 },
                    { 11, 4, 5 },
                    { 12, 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ZooAnimal",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zoos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
