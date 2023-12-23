using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTabalesForDogCatAndBird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimal_User_UserId",
                table: "UserAnimal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "AnimalModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanFly",
                table: "AnimalModel",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "AnimalModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AnimalModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dog_Breed",
                table: "AnimalModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dog_Weight",
                table: "AnimalModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LikesToPlay",
                table: "AnimalModel",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "AnimalModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimal_Users_UserId",
                table: "UserAnimal",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimal_Users_UserId",
                table: "UserAnimal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "CanFly",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "Dog_Breed",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "Dog_Weight",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "LikesToPlay",
                table: "AnimalModel");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AnimalModel");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimal_User_UserId",
                table: "UserAnimal",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
