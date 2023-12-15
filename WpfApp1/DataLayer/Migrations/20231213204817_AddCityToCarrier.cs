using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCityToCarrier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Carrier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 1,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 2,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 3,
                column: "CityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 4,
                column: "CityId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 5,
                column: "CityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 6,
                column: "CityId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 7,
                column: "CityId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 8,
                column: "CityId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 9,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 10,
                column: "CityId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 11,
                column: "CityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 12,
                column: "CityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Carrier",
                keyColumn: "cID",
                keyValue: 13,
                column: "CityId",
                value: 7);

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Windsor" },
                    { 2, "Hamilton" },
                    { 3, "Oshawa" },
                    { 4, "BelleVille" },
                    { 5, "Ottawa" },
                    { 6, "London" },
                    { 7, "Toronto" },
                    { 8, "Kingston" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrier_CityId",
                table: "Carrier",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrier_City_CityId",
                table: "Carrier",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrier_City_CityId",
                table: "Carrier");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Carrier_CityId",
                table: "Carrier");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Carrier");
        }
    }
}
