using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Data.Migrations
{
    public partial class addrolesanduseradmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6b51655c-f94f-4b2a-b731-007a457c803c"), "178d546c-c339-4f15-957d-4a3f57765b62", "admin", "ADMIN" },
                    { new Guid("950b4394-cdd4-4c13-aec3-b3002606d6b2"), "aa89a2a5-37c9-4102-9221-95b8e79b39ed", "client", "CLIENT" },
                    { new Guid("bb68dc1b-7275-4f13-b9a9-eb5d41e52bef"), "3ac5d558-88fd-4154-8559-c69f9a0f56db", "seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9809e203-28fd-421f-b628-524263456362"), 0, "3891ed99-c249-4d34-93b2-e801b1a09bf9", "admin@admin.com.br", true, false, null, "ADMIN@ADMIN.COM.BR", "ADMIN", "AQAAAAEAACcQAAAAELy7yLVj6IWxDxTuKZLEdFzbC2V4hv6xrJvRi1VRwE0ojQD28wLay7Ngf5DWQIGwKA==", null, false, "0915c892-6a51-450e-a95b-618605f57adb", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b51655c-f94f-4b2a-b731-007a457c803c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("950b4394-cdd4-4c13-aec3-b3002606d6b2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb68dc1b-7275-4f13-b9a9-eb5d41e52bef"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9809e203-28fd-421f-b628-524263456362"));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }
    }
}
