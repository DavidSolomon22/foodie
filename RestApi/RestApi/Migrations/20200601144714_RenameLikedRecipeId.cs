using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class RenameLikedRecipeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedRecipes",
                table: "LikedRecipes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ca0b409-0e4c-431d-b08c-3c8ce4385849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "319b2591-e1e1-416d-8006-6fd4be7c1dfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ac62bbf-b9cc-4421-a32b-5132dfb27caa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b77b934e-ce2d-48e1-8ff4-f7b42ed3b8a0");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LikedRecipes");

            migrationBuilder.AddColumn<Guid>(
                name: "LikedRecipeId",
                table: "LikedRecipes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedRecipes",
                table: "LikedRecipes",
                column: "LikedRecipeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ead71805-377d-4c16-bac2-c6f46bb80b82", "a73722a5-74c9-411d-882a-769e13decb32", "Administrator", "ADMINISTRATOR" },
                    { "8cc7791e-686c-4786-90ca-5235cfccea9e", "8083f0bb-d973-4a53-8b45-73763c46146c", "Developer", "DEVELOPER" },
                    { "4dc437bf-edae-43fd-913f-a788d2813ae8", "114faa88-439f-4d21-99c7-1c81f5af264c", "User", "USER" },
                    { "324651ca-ee02-4588-89b3-10672f8d6320", "b0d7fa84-eed2-438e-820c-467bb75a26f2", "PremiumUser", "PREMIUMUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedRecipes",
                table: "LikedRecipes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "324651ca-ee02-4588-89b3-10672f8d6320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dc437bf-edae-43fd-913f-a788d2813ae8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc7791e-686c-4786-90ca-5235cfccea9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ead71805-377d-4c16-bac2-c6f46bb80b82");

            migrationBuilder.DropColumn(
                name: "LikedRecipeId",
                table: "LikedRecipes");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "LikedRecipes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedRecipes",
                table: "LikedRecipes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ca0b409-0e4c-431d-b08c-3c8ce4385849", "11890b2d-7055-43cc-8cb8-296eb96e0e46", "Administrator", "ADMINISTRATOR" },
                    { "6ac62bbf-b9cc-4421-a32b-5132dfb27caa", "819bc257-bfbf-4246-aa3f-03fdf9bf47ff", "Developer", "DEVELOPER" },
                    { "319b2591-e1e1-416d-8006-6fd4be7c1dfd", "1dbd3610-ff65-4584-9af2-22525f36d1cf", "User", "USER" },
                    { "b77b934e-ce2d-48e1-8ff4-f7b42ed3b8a0", "eb1bcc9e-ead9-4cc6-b0c7-a77c1efff1b6", "PremiumUser", "PREMIUMUSER" }
                });
        }
    }
}
