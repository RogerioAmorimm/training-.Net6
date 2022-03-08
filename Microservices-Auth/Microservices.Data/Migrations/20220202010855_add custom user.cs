using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Data.Migrations
{
    public partial class addcustomuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("09b84653-a821-4b9a-886c-18379c05ec9c"), "fb7ca0af-61a3-42c4-b4f3-a3feff611172", "client", "CLIENT" },
                    { new Guid("18d9fb27-6dbc-488b-9353-07041dd3eaa8"), "c3f1397b-2ad9-4d24-8848-d624c64cc9b0", "admin", "ADMIN" },
                    { new Guid("d7bdc0fc-c786-4c1a-96d2-1030d7de7f8d"), "43494d13-e201-4bc0-a7eb-a19b4400fdd0", "seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e1e011ac-af19-4b05-bd62-7253ce902c6d"), 0, "ecd6d9d8-613e-4637-a181-01339a69019c", "admin@admin.com.br", true, false, null, "ADMIN@ADMIN.COM.BR", "ADMIN", "AQAAAAEAACcQAAAAEJcTxybGXc+jm3+pOCea+AQEQDhurILWyxXPAnPCzpp1RgGpVFlN3e1dFi+XopT2XA==", null, false, "e43b4fca-607e-4a62-81c3-a44565a87f10", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09b84653-a821-4b9a-886c-18379c05ec9c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18d9fb27-6dbc-488b-9353-07041dd3eaa8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7bdc0fc-c786-4c1a-96d2-1030d7de7f8d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e1e011ac-af19-4b05-bd62-7253ce902c6d"));

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
    }
}
