using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class AddUserPhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "AspNetUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "AspNetUsers");

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
    }
}
