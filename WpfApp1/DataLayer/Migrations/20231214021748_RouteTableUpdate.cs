using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RouteTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrierID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CarrierID",
                table: "Order",
                column: "CarrierID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Carrier_CarrierID",
                table: "Order",
                column: "CarrierID",
                principalTable: "Carrier",
                principalColumn: "cID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Carrier_CarrierID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CarrierID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CarrierID",
                table: "Order");
        }
    }
}
