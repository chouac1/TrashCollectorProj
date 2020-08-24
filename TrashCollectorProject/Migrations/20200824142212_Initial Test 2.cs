using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class InitialTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "046b8fca-e0be-458c-8366-6d5b9fd247bc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44c7f123-a418-4f72-935b-733fc0b6f85f", "608b8176-2c09-44f6-8cb0-5b0db909c3ab", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44c7f123-a418-4f72-935b-733fc0b6f85f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "046b8fca-e0be-458c-8366-6d5b9fd247bc", "327ec671-003d-4fc9-8d63-a2f8531b3582", "Admin", "ADMIN" });
        }
    }
}
