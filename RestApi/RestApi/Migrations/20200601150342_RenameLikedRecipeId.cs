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
                    { "f1222543-530f-4494-953f-3914436c7ba4", "a287a011-c246-448b-9c96-21d47e819e5a", "Administrator", "ADMINISTRATOR" },
                    { "2ae63216-6df2-4133-adea-3b75cbaab5d0", "99305106-22d2-40c9-b49b-bb46f7bf1c5d", "Developer", "DEVELOPER" },
                    { "69e4b95e-11a8-4151-836d-030a6db0145e", "de7b14ba-4752-428b-b9b0-5eb63fbda1ce", "User", "USER" },
                    { "f1c05552-2b33-4891-b041-db4941365cc8", "509cdda2-af49-4bba-8818-111f86303c3e", "PremiumUser", "PREMIUMUSER" }
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
                keyValue: "2ae63216-6df2-4133-adea-3b75cbaab5d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69e4b95e-11a8-4151-836d-030a6db0145e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1222543-530f-4494-953f-3914436c7ba4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1c05552-2b33-4891-b041-db4941365cc8");

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
