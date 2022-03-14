using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class roleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "8762f7b4-e3f9-4117-afa7-759f45a8bef4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 9998, "9654dbb6-9399-4ee9-9d09-b5bf51b2d464", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32e13b66-a4aa-41fc-8e72-0ef0b2484689", "AQAAAAEAACcQAAAAEG1Ulo8oP+WiEKcS9jsDPeT6pdfRM5gngSA0gUHrzWGGOhZxoO6+AVOulTIGAePRTA==", "700ebb42-8e4a-4435-a8c1-a395aad01dd9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "7916a87d-88db-4c4b-b83f-741c558640ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b892258-7477-48ea-a144-516a03b41fd1", "AQAAAAEAACcQAAAAEOUBChR/6xHPSjODVVs//NwMpa2G5JeMTPT6G9JfBTH7atAa99pBTRQea6FTtR4Duw==", "0759e23f-af14-4ec5-b1b3-3f9684b1cd42" });
        }
    }
}
