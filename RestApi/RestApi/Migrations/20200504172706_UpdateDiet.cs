using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class UpdateDiet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1102c49b-41c0-43dd-a456-bc66a9407e96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f37787a-1052-4209-aac2-d8e1a46bb385");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cc494a7-1d41-48d5-be03-0288b7bb36f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90024f84-7de5-4a95-9db6-d8f5f96261b5");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Diets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Diets",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Day",
                table: "DailyDiets",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07f88c26-12ff-45b7-a28c-902f15850e94", "444f5cc6-dcd1-4971-8800-8a9ca1f064cc", "Administrator", "ADMINISTRATOR" },
                    { "d1131f87-22b1-4e27-9e24-51b3b106c522", "ad25fd65-cd21-4e85-ac15-5f271c0d433b", "Developer", "DEVELOPER" },
                    { "6c33a444-9576-44f1-92d6-3669bb4ee059", "f465222a-4ff1-43b7-94ef-2b8bbe74fafe", "User", "USER" },
                    { "357399ee-0698-43bc-9a22-038ea5cc65d3", "8d50c9ba-3df0-46a8-b5fe-fd9491c4b46a", "PremiumUser", "PREMIUMUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07f88c26-12ff-45b7-a28c-902f15850e94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "357399ee-0698-43bc-9a22-038ea5cc65d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c33a444-9576-44f1-92d6-3669bb4ee059");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1131f87-22b1-4e27-9e24-51b3b106c522");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Diets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "DailyDiets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90024f84-7de5-4a95-9db6-d8f5f96261b5", "637b61ab-aad7-47f7-8205-68ce2c445afa", "Administrator", "ADMINISTRATOR" },
                    { "1102c49b-41c0-43dd-a456-bc66a9407e96", "091a2022-83fe-4d5b-b656-b18eaf535812", "Developer", "DEVELOPER" },
                    { "7cc494a7-1d41-48d5-be03-0288b7bb36f5", "ed2da36a-2ad5-4630-a4d5-c531e934b292", "User", "USER" },
                    { "2f37787a-1052-4209-aac2-d8e1a46bb385", "63b0830a-3758-4c7f-bf41-33b1777b5f10", "PremiumUser", "PREMIUMUSER" }
                });
        }
    }
}
