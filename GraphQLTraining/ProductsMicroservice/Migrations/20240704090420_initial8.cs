using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class initial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productfacet_categoryproducts_sku_categoryid",
                table: "productfacet");

            migrationBuilder.DropPrimaryKey(
                name: "pk_productfacet",
                table: "productfacet");

            migrationBuilder.RenameTable(
                name: "productfacet",
                newName: "productfacets");

            migrationBuilder.RenameIndex(
                name: "ix_productfacet_sku_categoryid",
                table: "productfacets",
                newName: "ix_productfacets_sku_categoryid");

            migrationBuilder.RenameIndex(
                name: "ix_productfacet_fieldname",
                table: "productfacets",
                newName: "ix_productfacets_fieldname");

            migrationBuilder.AddPrimaryKey(
                name: "pk_productfacets",
                table: "productfacets",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_productfacets_categoryproducts_sku_categoryid",
                table: "productfacets",
                columns: new[] { "sku", "categoryid" },
                principalTable: "categoryproducts",
                principalColumns: new[] { "productsku", "categoryid" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productfacets_categoryproducts_sku_categoryid",
                table: "productfacets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_productfacets",
                table: "productfacets");

            migrationBuilder.RenameTable(
                name: "productfacets",
                newName: "productfacet");

            migrationBuilder.RenameIndex(
                name: "ix_productfacets_sku_categoryid",
                table: "productfacet",
                newName: "ix_productfacet_sku_categoryid");

            migrationBuilder.RenameIndex(
                name: "ix_productfacets_fieldname",
                table: "productfacet",
                newName: "ix_productfacet_fieldname");

            migrationBuilder.AddPrimaryKey(
                name: "pk_productfacet",
                table: "productfacet",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_productfacet_categoryproducts_sku_categoryid",
                table: "productfacet",
                columns: new[] { "sku", "categoryid" },
                principalTable: "categoryproducts",
                principalColumns: new[] { "productsku", "categoryid" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
