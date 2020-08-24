using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class RedidemployeeMODELunsureastowhyitisnottakingtheFKIDENTITYUSER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "572737e9-0d99-423d-91e7-c3c3276115a7");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Employee",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "faddc401-2c1c-48c6-8b55-c5ecc5b8d466", "846c018b-def4-4827-9635-8d0558078536", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faddc401-2c1c-48c6-8b55-c5ecc5b8d466");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Employee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "572737e9-0d99-423d-91e7-c3c3276115a7", "6aa5de77-0e45-41e9-8440-464af48fdedc", "Admin", "ADMIN" });
        }
    }
}
