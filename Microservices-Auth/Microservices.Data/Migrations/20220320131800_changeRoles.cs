using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Data.Migrations
{
    public partial class changeRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("55027ec4-ba5b-49a0-85dc-d63daeb68628"), "3d1b9c3f-66f9-4e03-8306-7aebd6d90138", "consumer", "CONSUMER" },
                    { new Guid("a4e91c17-f845-4317-9295-587285a126be"), "1ea64de3-866e-4838-9a0f-61d890216b11", "admin", "ADMIN" },
                    { new Guid("fe7d69e6-668f-43db-bd94-91f6fd1ba3e1"), "a34313e5-1d9a-4101-9e0a-7adfd4a12879", "producer", "PRODUCER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("63414998-0373-457c-8767-8c91d1892cca"), 0, "bd40cfda-22c4-4637-86f0-9b48c84ddde6", "admin@admin.com.br", true, false, null, "ADMIN@ADMIN.COM.BR", "ADMIN", "AQAAAAEAACcQAAAAENpj8k7Dz7fEb++Kf0VboxUNH30vdpOIV+jNUkVwPRgOed+umZxrUbWBF4HOTNCfPw==", null, false, "c7f6f0e6-5d63-4aac-a891-bac29a02b80a", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("55027ec4-ba5b-49a0-85dc-d63daeb68628"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a4e91c17-f845-4317-9295-587285a126be"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe7d69e6-668f-43db-bd94-91f6fd1ba3e1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63414998-0373-457c-8767-8c91d1892cca"));

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
    }
}
