using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string[]>(
                name: "excludedcountries",
                table: "products",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "friendlyurl",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "instruction",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isarchived",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdiamond",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isoutofstock",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "noindex",
                table: "products",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "upperdescription",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "usefriendlyurl",
                table: "products",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "products");

            migrationBuilder.DropColumn(
                name: "excludedcountries",
                table: "products");

            migrationBuilder.DropColumn(
                name: "friendlyurl",
                table: "products");

            migrationBuilder.DropColumn(
                name: "instruction",
                table: "products");

            migrationBuilder.DropColumn(
                name: "isactive",
                table: "products");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "products");

            migrationBuilder.DropColumn(
                name: "isdiamond",
                table: "products");

            migrationBuilder.DropColumn(
                name: "isoutofstock",
                table: "products");

            migrationBuilder.DropColumn(
                name: "name",
                table: "products");

            migrationBuilder.DropColumn(
                name: "noindex",
                table: "products");

            migrationBuilder.DropColumn(
                name: "upperdescription",
                table: "products");

            migrationBuilder.DropColumn(
                name: "url",
                table: "products");

            migrationBuilder.DropColumn(
                name: "usefriendlyurl",
                table: "products");
        }
    }
}
