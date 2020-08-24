using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class IDENTITYUSERForeignKeyaddedintoEmployeemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "880fa07a-42dd-45de-9de1-ab5c23597979");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "572737e9-0d99-423d-91e7-c3c3276115a7", "6aa5de77-0e45-41e9-8440-464af48fdedc", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "572737e9-0d99-423d-91e7-c3c3276115a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "880fa07a-42dd-45de-9de1-ab5c23597979", "65f9343b-b99f-4139-84f8-915d2e18fa55", "Admin", "ADMIN" });
        }
    }
}
