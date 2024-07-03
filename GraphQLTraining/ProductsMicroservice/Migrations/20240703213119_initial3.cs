using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productfacet_categoryproduct_sku_categoryid",
                table: "productfacet");

            migrationBuilder.DropForeignKey(
                name: "fk_productsincategories_categoryproduct_sku_categoryid",
                table: "productsincategories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_categoryproduct",
                table: "categoryproduct");

            migrationBuilder.DropColumn(
                name: "sku",
                table: "categoryproduct");

            migrationBuilder.AddPrimaryKey(
                name: "pk_categoryproduct",
                table: "categoryproduct",
                columns: new[] { "productsku", "categoryid" });

            migrationBuilder.AddForeignKey(
                name: "fk_productfacet_categoryproduct_sku_categoryid",
                table: "productfacet",
                columns: new[] { "sku", "categoryid" },
                principalTable: "categoryproduct",
                principalColumns: new[] { "productsku", "categoryid" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productsincategories_categoryproduct_sku_categoryid",
                table: "productsincategories",
                columns: new[] { "sku", "categoryid" },
                principalTable: "categoryproduct",
                principalColumns: new[] { "productsku", "categoryid" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productfacet_categoryproduct_sku_categoryid",
                table: "productfacet");

            migrationBuilder.DropForeignKey(
                name: "fk_productsincategories_categoryproduct_sku_categoryid",
                table: "productsincategories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_categoryproduct",
                table: "categoryproduct");

            migrationBuilder.AddColumn<string>(
                name: "sku",
                table: "categoryproduct",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_categoryproduct",
                table: "categoryproduct",
                columns: new[] { "sku", "categoryid" });

            migrationBuilder.AddForeignKey(
                name: "fk_productfacet_categoryproduct_sku_categoryid",
                table: "productfacet",
                columns: new[] { "sku", "categoryid" },
                principalTable: "categoryproduct",
                principalColumns: new[] { "sku", "categoryid" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productsincategories_categoryproduct_sku_categoryid",
                table: "productsincategories",
                columns: new[] { "sku", "categoryid" },
                principalTable: "categoryproduct",
                principalColumns: new[] { "sku", "categoryid" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
