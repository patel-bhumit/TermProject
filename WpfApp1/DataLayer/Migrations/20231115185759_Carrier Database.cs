using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CarrierDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "login",
                keyColumn: "Username",
                keyValue: "user");

            migrationBuilder.CreateTable(
                name: "Carrier",
                columns: table => new
                {
                    cID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dCity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FTLA = table.Column<int>(type: "int", nullable: false),
                    LTLA = table.Column<int>(type: "int", nullable: false),
                    FTLARate = table.Column<double>(type: "double", nullable: false),
                    LTLRate = table.Column<double>(type: "double", nullable: false),
                    reefCharge = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrier", x => x.cID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Carrier",
                columns: new[] { "cID", "FTLA", "FTLARate", "LTLA", "LTLRate", "cName", "dCity", "reefCharge" },
                values: new object[,]
                {
                    { 1, 50, 5.21, 640, 0.36209999999999998, "Planet Express", "Windsor", 0.080000000000000002 },
                    { 2, 50, 5.21, 640, 0.36209999999999998, "Planet Express", "Hamilton", 0.080000000000000002 },
                    { 3, 50, 5.21, 640, 0.36209999999999998, "Planet Express", "Oshawa", 0.080000000000000002 },
                    { 4, 50, 5.21, 640, 0.36209999999999998, "Planet Express", "Belleville", 0.080000000000000002 },
                    { 5, 50, 5.21, 640, 0.36209999999999998, "Planet Express", "Ottawa", 0.080000000000000002 },
                    { 6, 18, 5.0499999999999998, 98, 0.34339999999999998, "Schooner's", "London", 0.070000000000000007 },
                    { 7, 18, 5.0499999999999998, 98, 0.34339999999999998, "Schooner's", "Toronto", 0.070000000000000007 },
                    { 8, 18, 5.0499999999999998, 98, 0.34339999999999998, "Schooner's", "Kingston", 0.070000000000000007 },
                    { 9, 24, 5.1100000000000003, 35, 0.30120000000000002, "Tillman Transport", "Windsor", 0.089999999999999997 },
                    { 10, 18, 5.1100000000000003, 45, 0.30120000000000002, "Tillman Transport", "London", 0.089999999999999997 },
                    { 11, 18, 5.1100000000000003, 45, 0.30120000000000002, "Tillman Transport", "Hamilton", 0.089999999999999997 },
                    { 12, 11, 5.2000000000000002, 0, 0.0, "We Haul", "Ottawa", 0.065000000000000002 },
                    { 13, 11, 5.2000000000000002, 0, 0.0, "We Haul", "Toronto", 0.065000000000000002 }
                });

            migrationBuilder.InsertData(
                table: "login",
                columns: new[] { "Username", "Password", "Role" },
                values: new object[,]
                {
                    { "buyer", "buyer", "buyer" },
                    { "planner", "planner", "planner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrier");

            migrationBuilder.DeleteData(
                table: "login",
                keyColumn: "Username",
                keyValue: "buyer");

            migrationBuilder.DeleteData(
                table: "login",
                keyColumn: "Username",
                keyValue: "planner");

            migrationBuilder.InsertData(
                table: "login",
                columns: new[] { "Username", "Password", "Role" },
                values: new object[] { "user", "user", "user" });
        }
    }
}
