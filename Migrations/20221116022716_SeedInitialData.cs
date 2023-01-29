using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCrud.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isAdmin" },
                values: new object[] { "c13657a6-e6d3-490d-a543-a35ffcd1e039", 0, "18d41615-7614-4d5a-8c51-6bb449e2bd36", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKv0EIjfkGuaTKbyL9pK2Ds4BRilUcnVwzh8CLqIHkRUf39c9sFujBpcQdMaBzQ7bw==", null, false, "TIECJY2NDQZ66FU2BH6PZF55LJTBI2PX", false, "admin@admin.com", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c13657a6-e6d3-490d-a543-a35ffcd1e039");
        }
    }
}
