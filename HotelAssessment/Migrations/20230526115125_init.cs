using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAssessment.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Hotels_CustomerHotelId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Hotels_RoomHotelId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "RoomHotelId",
                table: "Bookings",
                newName: "RoomNo");

            migrationBuilder.RenameColumn(
                name: "CustomerHotelId",
                table: "Bookings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomHotelId",
                table: "Bookings",
                newName: "IX_Bookings_RoomNo");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerHotelId",
                table: "Bookings",
                newName: "IX_Bookings_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomNo",
                table: "Bookings",
                column: "RoomNo",
                principalTable: "Rooms",
                principalColumn: "RoomNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomNo",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "RoomNo",
                table: "Bookings",
                newName: "RoomHotelId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Bookings",
                newName: "CustomerHotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomNo",
                table: "Bookings",
                newName: "IX_Bookings_RoomHotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                newName: "IX_Bookings_CustomerHotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Hotels_CustomerHotelId",
                table: "Bookings",
                column: "CustomerHotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Hotels_RoomHotelId",
                table: "Bookings",
                column: "RoomHotelId",
                principalTable: "Hotels",
                principalColumn: "HotelId");
        }
    }
}
