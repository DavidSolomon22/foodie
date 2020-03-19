using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9bf7b003-9a12-420f-b686-0e9e848ff6b4", "4489568a-0eca-41cf-b26e-5cd0b3ed8270", "Administrator", "ADMINISTRATOR" },
                    { "1422bf2f-bb1d-4789-9207-8fc660490fd0", "4b67fb64-75bc-4db2-a432-6ba695deee91", "Developer", "DEVELOPER" },
                    { "63e9827b-c3c0-4da4-8b0d-707a83a14a54", "b67b26c6-f895-4234-88db-dba7556b6239", "User", "USER" },
                    { "b74e6ce9-5eb9-4fad-a327-b17767647e14", "f6af53fe-27e6-4ea1-aaf0-e1407b272e3c", "PremiumUser", "PREMIUMUSER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1422bf2f-bb1d-4789-9207-8fc660490fd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63e9827b-c3c0-4da4-8b0d-707a83a14a54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bf7b003-9a12-420f-b686-0e9e848ff6b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b74e6ce9-5eb9-4fad-a327-b17767647e14");
        }
    }
}
