using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categoryproduct_categories_categoryid",
                table: "categoryproduct");

            migrationBuilder.DropForeignKey(
                name: "fk_categoryproduct_products_productsku_productversionid_produc~",
                table: "categoryproduct");

            migrationBuilder.DropForeignKey(
                name: "fk_productfacet_categoryproduct_sku_categoryid",
                table: "productfacet");

            migrationBuilder.DropPrimaryKey(
                name: "pk_categoryproduct",
                table: "categoryproduct");

            migrationBuilder.RenameTable(
                name: "categoryproduct",
                newName: "categoryproducts");

            migrationBuilder.RenameIndex(
                name: "ix_categoryproduct_productsku_productversionid_productcurrency~",
                table: "categoryproducts",
                newName: "ix_categoryproducts_productsku_productversionid_productcurrenc~");

            migrationBuilder.RenameIndex(
                name: "ix_categoryproduct_categoryid",
                table: "categoryproducts",
                newName: "ix_categoryproducts_categoryid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_categoryproducts",
                table: "categoryproducts",
                columns: new[] { "productsku", "categoryid" });

            migrationBuilder.AddForeignKey(
                name: "fk_categoryproducts_categories_categoryid",
                table: "categoryproducts",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "categoryexternalid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_categoryproducts_products_productsku_productversionid_produ~",
                table: "categoryproducts",
                columns: new[] { "productsku", "productversionid", "productcurrencycode" },
                principalTable: "products",
                principalColumns: new[] { "sku", "versionid", "currencycode" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productfacet_categoryproducts_sku_categoryid",
                table: "productfacet",
                columns: new[] { "sku", "categoryid" },
                principalTable: "categoryproducts",
                principalColumns: new[] { "productsku", "categoryid" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categoryproducts_categories_categoryid",
                table: "categoryproducts");

            migrationBuilder.DropForeignKey(
                name: "fk_categoryproducts_products_productsku_productversionid_produ~",
                table: "categoryproducts");

            migrationBuilder.DropForeignKey(
                name: "fk_productfacet_categoryproducts_sku_categoryid",
                table: "productfacet");

            migrationBuilder.DropPrimaryKey(
                name: "pk_categoryproducts",
                table: "categoryproducts");

            migrationBuilder.RenameTable(
                name: "categoryproducts",
                newName: "categoryproduct");

            migrationBuilder.RenameIndex(
                name: "ix_categoryproducts_productsku_productversionid_productcurrenc~",
                table: "categoryproduct",
                newName: "ix_categoryproduct_productsku_productversionid_productcurrency~");

            migrationBuilder.RenameIndex(
                name: "ix_categoryproducts_categoryid",
                table: "categoryproduct",
                newName: "ix_categoryproduct_categoryid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_categoryproduct",
                table: "categoryproduct",
                columns: new[] { "productsku", "categoryid" });

            migrationBuilder.AddForeignKey(
                name: "fk_categoryproduct_categories_categoryid",
                table: "categoryproduct",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "categoryexternalid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_categoryproduct_products_productsku_productversionid_produc~",
                table: "categoryproduct",
                columns: new[] { "productsku", "productversionid", "productcurrencycode" },
                principalTable: "products",
                principalColumns: new[] { "sku", "versionid", "currencycode" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productfacet_categoryproduct_sku_categoryid",
                table: "productfacet",
                columns: new[] { "sku", "categoryid" },
                principalTable: "categoryproduct",
                principalColumns: new[] { "productsku", "categoryid" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
