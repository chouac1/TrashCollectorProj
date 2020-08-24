using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class WeeklyPickupaddedtocustomermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44c7f123-a418-4f72-935b-733fc0b6f85f");

            migrationBuilder.AddColumn<string>(
                name: "WeeklyPickup",
                table: "Customer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fdf6d6c-f8f9-4b89-9767-f80998433d0a", "2d726d1b-dbc7-49e3-93ac-8bb3dcf1785d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fdf6d6c-f8f9-4b89-9767-f80998433d0a");

            migrationBuilder.DropColumn(
                name: "WeeklyPickup",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44c7f123-a418-4f72-935b-733fc0b6f85f", "608b8176-2c09-44f6-8cb0-5b0db909c3ab", "Admin", "ADMIN" });
        }
    }
}
