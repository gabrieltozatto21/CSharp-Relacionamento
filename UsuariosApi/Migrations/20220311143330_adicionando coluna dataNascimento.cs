using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class adicionandocolunadataNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9998,
                column: "ConcurrencyStamp",
                value: "6b6fe79c-01ea-4248-9f68-03c0e46d1f49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "ea9d1d72-6597-42c0-9e53-d33ec5b5200c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db2914c6-2add-4d19-9234-c59a2abc1a2e", "AQAAAAEAACcQAAAAEMjUGyTwvkO6icNNAROn2+z1CSS5eWiB2RcRp8oWtBKFn8H8KewXBmnVg1IHXwN5pw==", "63f377dd-8648-4729-885e-36ce8f0a9521" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9998,
                column: "ConcurrencyStamp",
                value: "9654dbb6-9399-4ee9-9d09-b5bf51b2d464");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "8762f7b4-e3f9-4117-afa7-759f45a8bef4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32e13b66-a4aa-41fc-8e72-0ef0b2484689", "AQAAAAEAACcQAAAAEG1Ulo8oP+WiEKcS9jsDPeT6pdfRM5gngSA0gUHrzWGGOhZxoO6+AVOulTIGAePRTA==", "700ebb42-8e4a-4435-a8c1-a395aad01dd9" });
        }
    }
}
