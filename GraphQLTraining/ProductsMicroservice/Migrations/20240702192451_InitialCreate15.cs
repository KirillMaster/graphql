using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_label_category_categoryuid",
                table: "label");

            migrationBuilder.DropPrimaryKey(
                name: "pk_label",
                table: "label");

            migrationBuilder.AlterColumn<string>(
                name: "categoryuid",
                table: "label",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "label",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_label",
                table: "label",
                columns: new[] { "id", "categoryuid" });

            migrationBuilder.AddForeignKey(
                name: "fk_label_category_categoryuid",
                table: "label",
                column: "categoryuid",
                principalTable: "category",
                principalColumn: "uid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_label_category_categoryuid",
                table: "label");

            migrationBuilder.DropPrimaryKey(
                name: "pk_label",
                table: "label");

            migrationBuilder.AlterColumn<string>(
                name: "categoryuid",
                table: "label",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "label",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_label",
                table: "label",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_label_category_categoryuid",
                table: "label",
                column: "categoryuid",
                principalTable: "category",
                principalColumn: "uid");
        }
    }
}
