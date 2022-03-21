using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Data.Migrations
{
    public partial class addrelationfromAdminRoletoAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("254b2e53-354f-4f5b-9d3b-d076c7d23573"), "69bc03e8-4651-41da-ab52-c45483c0000e", "consumer", "CONSUMER" },
                    { new Guid("be510ef3-de6e-4806-975f-2fb4b53a8658"), "cba7927d-0979-431f-b13d-d63e3ba95073", "producer", "PRODUCER" },
                    { new Guid("cdcedca5-c0a1-492a-9121-1b5a4723b2c3"), "29b1d8a6-c312-499f-9ce2-9c4e9b75582d", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b4e3d78d-9344-454a-8c5d-ed269c0d8ba7"), 0, "df8bd582-44d9-4964-914b-c93db16eb8be", "admin@admin.com.br", true, false, null, "ADMIN@ADMIN.COM.BR", "ADMIN", "AQAAAAEAACcQAAAAEBRaT3EAnhlTOHDogjgEGVnsrzSTMt9XKeQ8yhqlEsnwkm+PeaQ0v4ZdOK6e39DPtw==", null, false, "4d316f67-f9a4-4c73-8c04-c21d2333f785", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cdcedca5-c0a1-492a-9121-1b5a4723b2c3"), new Guid("b4e3d78d-9344-454a-8c5d-ed269c0d8ba7") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("254b2e53-354f-4f5b-9d3b-d076c7d23573"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be510ef3-de6e-4806-975f-2fb4b53a8658"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cdcedca5-c0a1-492a-9121-1b5a4723b2c3"), new Guid("b4e3d78d-9344-454a-8c5d-ed269c0d8ba7") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdcedca5-c0a1-492a-9121-1b5a4723b2c3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4e3d78d-9344-454a-8c5d-ed269c0d8ba7"));

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
    }
}
