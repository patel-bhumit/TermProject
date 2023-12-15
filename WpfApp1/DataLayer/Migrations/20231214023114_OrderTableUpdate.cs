using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class OrderTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "cID",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_cID",
                table: "Order",
                column: "cID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Carrier_cID",
                table: "Order",
                column: "cID",
                principalTable: "Carrier",
                principalColumn: "cID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Carrier_cID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_cID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "cID",
                table: "Order");

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
    }
}
