using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RouteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrierCapacity");

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cID = table.Column<int>(type: "int", nullable: false),
                    CarrierName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DestinationCity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_Route_Carrier_cID",
                        column: x => x.cID,
                        principalTable: "Carrier",
                        principalColumn: "cID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "RouteID", "CarrierName", "DestinationCity", "cID" },
                values: new object[,]
                {
                    { 1, "Planet Express", "Windsor", 1 },
                    { 2, "Planet Express", "Hamilton", 2 },
                    { 3, "Planet Express", "Oshawa", 3 },
                    { 4, "Planet Express", "Belleville", 4 },
                    { 5, "Planet Express", "Ottawa", 5 },
                    { 6, "Schooner's", "London", 6 },
                    { 7, "Schooner's", "Toronto", 7 },
                    { 8, "Schooner's", "Kingston", 8 },
                    { 9, "Tillman Transport", "Windsor", 9 },
                    { 10, "Tillman Transport", "London", 10 },
                    { 11, "Tillman Transport", "Hamilton", 11 },
                    { 12, "We Haul", "Ottawa", 12 },
                    { 13, "We Haul", "Toronto", 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Route_cID",
                table: "Route",
                column: "cID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.CreateTable(
                name: "CarrierCapacity",
                columns: table => new
                {
                    CarrierID = table.Column<int>(type: "int", nullable: false),
                    MaxTrips = table.Column<int>(type: "int", nullable: false),
                    VolumeLimit = table.Column<int>(type: "int", nullable: false),
                    WeightLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierCapacity", x => x.CarrierID);
                    table.ForeignKey(
                        name: "FK_CarrierCapacity_Carrier_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "Carrier",
                        principalColumn: "cID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
