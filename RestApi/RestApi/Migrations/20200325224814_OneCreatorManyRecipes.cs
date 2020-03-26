using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class OneCreatorManyRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipes_CreatorId",
                table: "Recipes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "703f60a0-e847-494f-92b4-3e36a3ce8255");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f59c04-276b-4382-bcb7-40e147301064");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5cfa3c9-a786-4f09-84a2-75f5fe51df54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d09818a7-a350-49bf-a720-ab1b867d4bc1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66bce5f3-2ecc-4598-a201-54a8ac4dcf3a", "75f2040b-e50d-4a15-8d06-73edf4560d9a", "Administrator", "ADMINISTRATOR" },
                    { "54021aae-9b90-4887-8c8b-8cb3c423391c", "ff37ca11-19b6-430d-b334-bdac289c690a", "Developer", "DEVELOPER" },
                    { "12490bb6-31f5-4151-8d4e-70493f0a5e6a", "57419bc2-ab2c-469c-b138-728dbb562423", "User", "USER" },
                    { "6f9390b0-74c3-4e53-b38e-916dfe922577", "fff8113b-ba02-4878-87ab-9000edbfaf1d", "PremiumUser", "PREMIUMUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatorId",
                table: "Recipes",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipes_CreatorId",
                table: "Recipes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12490bb6-31f5-4151-8d4e-70493f0a5e6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54021aae-9b90-4887-8c8b-8cb3c423391c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66bce5f3-2ecc-4598-a201-54a8ac4dcf3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f9390b0-74c3-4e53-b38e-916dfe922577");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d09818a7-a350-49bf-a720-ab1b867d4bc1", "635710bc-a0ed-407d-bf97-da46dd82b4c2", "Administrator", "ADMINISTRATOR" },
                    { "98f59c04-276b-4382-bcb7-40e147301064", "e5af1dfd-6586-4f67-8cfa-283486877446", "Developer", "DEVELOPER" },
                    { "c5cfa3c9-a786-4f09-84a2-75f5fe51df54", "c123eb78-6f40-41e9-a076-cada0fb41ff1", "User", "USER" },
                    { "703f60a0-e847-494f-92b4-3e36a3ce8255", "8a6730e9-d251-4666-99c8-09ddbc6abbae", "PremiumUser", "PREMIUMUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatorId",
                table: "Recipes",
                column: "CreatorId",
                unique: true,
                filter: "[CreatorId] IS NOT NULL");
        }
    }
}
