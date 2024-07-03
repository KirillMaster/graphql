using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_facet_categories_categoryid",
                table: "facet");

            migrationBuilder.DropPrimaryKey(
                name: "pk_facet",
                table: "facet");

            migrationBuilder.RenameTable(
                name: "facet",
                newName: "facets");

            migrationBuilder.RenameIndex(
                name: "ix_facet_fieldname",
                table: "facets",
                newName: "ix_facets_fieldname");

            migrationBuilder.RenameIndex(
                name: "ix_facet_categoryid",
                table: "facets",
                newName: "ix_facets_categoryid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_facets",
                table: "facets",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_facets_categories_categoryid",
                table: "facets",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "categoryexternalid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_facets_categories_categoryid",
                table: "facets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_facets",
                table: "facets");

            migrationBuilder.RenameTable(
                name: "facets",
                newName: "facet");

            migrationBuilder.RenameIndex(
                name: "ix_facets_fieldname",
                table: "facet",
                newName: "ix_facet_fieldname");

            migrationBuilder.RenameIndex(
                name: "ix_facets_categoryid",
                table: "facet",
                newName: "ix_facet_categoryid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_facet",
                table: "facet",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_facet_categories_categoryid",
                table: "facet",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "categoryexternalid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
