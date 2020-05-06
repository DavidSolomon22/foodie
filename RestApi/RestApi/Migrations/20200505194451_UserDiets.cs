using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class UserDiets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Diets_CreatorId",
                table: "Diets");

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

            migrationBuilder.CreateIndex(
                name: "IX_Diets_CreatorId",
                table: "Diets",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Diets_CreatorId",
                table: "Diets");

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

            migrationBuilder.CreateIndex(
                name: "IX_Diets_CreatorId",
                table: "Diets",
                column: "CreatorId",
                unique: true,
                filter: "[CreatorId] IS NOT NULL");
        }
    }
}
