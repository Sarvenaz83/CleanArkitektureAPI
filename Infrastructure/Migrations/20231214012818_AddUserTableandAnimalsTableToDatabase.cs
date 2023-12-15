using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTableandAnimalsTableToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalModel_Users_UserId",
                table: "AnimalModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalModel",
                table: "AnimalModel");

            migrationBuilder.DropIndex(
                name: "IX_AnimalModel_UserId",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CanFly",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "LikesToPlay",
                table: "AnimalModel");

            migrationBuilder.RenameTable(
                name: "AnimalModel",
                newName: "Dogs");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("052f257c-5633-4a62-8c47-ff37eb7f077d"), "Nonika", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("16e28a3a-e3c8-4dbf-8287-ff14c8f39b82"), "Sezar", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3318ed23-64d9-465e-be0f-cd67d3231194"), "Cortex", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("40bd192d-5399-46bc-874d-5d764fe25e2e"), "Feri", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("56b6529e-4432-4dc8-8095-f49baf497f8a"), "Misholak", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5db6aebf-3ced-4cc7-a717-0ab2191f1cea"), "Sherek", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("69c3340d-40dd-4c4d-9cac-1bbda6adaa1a"), "Fench", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("875fab97-9551-45fa-a7fb-38b67ff11273"), "Blåmess", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b74d7533-8f4c-4d7e-87a5-85d5151b7cbb"), "Pappy", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c782e528-9bb2-4f5c-92b5-f97c7bc0b18c"), "Serdar", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("fb1af747-31ba-402b-81be-0e374daba659"), "Mandy", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ff6d2bae-891a-458b-8473-7f1a1511fb3c"), "Simba", new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dogs",
                table: "Dogs");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("052f257c-5633-4a62-8c47-ff37eb7f077d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("16e28a3a-e3c8-4dbf-8287-ff14c8f39b82"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("3318ed23-64d9-465e-be0f-cd67d3231194"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("40bd192d-5399-46bc-874d-5d764fe25e2e"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("56b6529e-4432-4dc8-8095-f49baf497f8a"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("5db6aebf-3ced-4cc7-a717-0ab2191f1cea"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("69c3340d-40dd-4c4d-9cac-1bbda6adaa1a"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("875fab97-9551-45fa-a7fb-38b67ff11273"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("b74d7533-8f4c-4d7e-87a5-85d5151b7cbb"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("c782e528-9bb2-4f5c-92b5-f97c7bc0b18c"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("fb1af747-31ba-402b-81be-0e374daba659"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("ff6d2bae-891a-458b-8473-7f1a1511fb3c"));

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Dogs",
                newName: "AnimalModel");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CanFly",
                table: "AnimalModel",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AnimalModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "LikesToPlay",
                table: "AnimalModel",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalModel",
                table: "AnimalModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalModel_UserId",
                table: "AnimalModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalModel_Users_UserId",
                table: "AnimalModel",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
