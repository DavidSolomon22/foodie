using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c8c6fe1-1a7e-40a4-9cca-5bcf113463de", "81338563-0392-4038-93ec-28c71c6b1d5e", "Administrator", "ADMINISTRATOR" },
                    { "67f71a8e-c980-4171-8cc4-4fb96d33f933", "6a41f9dd-31ec-40d8-b41f-4a1d1e66ad70", "Developer", "DEVELOPER" },
                    { "274edc04-1ead-44a9-95bc-be8d24114d27", "288a2817-5228-42f2-83e2-e3b571bd2829", "User", "USER" },
                    { "0f346129-0aae-4bd8-b79c-a71c99f19a67", "988f1774-2948-419f-a934-43e17da21536", "PremiumUser", "PREMIUMUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c8c6fe1-1a7e-40a4-9cca-5bcf113463de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f346129-0aae-4bd8-b79c-a71c99f19a67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "274edc04-1ead-44a9-95bc-be8d24114d27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67f71a8e-c980-4171-8cc4-4fb96d33f933");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

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
        }
    }
}
