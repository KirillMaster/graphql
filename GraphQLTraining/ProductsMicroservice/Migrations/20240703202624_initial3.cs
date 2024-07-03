using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryexternalid = table.Column<Guid>(type: "uuid", nullable: false),
                    content_backofficename = table.Column<string>(type: "text", nullable: false),
                    content_name = table.Column<string>(type: "text", nullable: false),
                    content_urlname = table.Column<string>(type: "text", nullable: false),
                    content_categorydescription = table.Column<string>(type: "text", nullable: false),
                    content_categoryimagelink = table.Column<string>(type: "text", nullable: false),
                    content_imagetitle = table.Column<string>(type: "text", nullable: false),
                    content_imagealt = table.Column<string>(type: "text", nullable: false),
                    seo_id = table.Column<int>(type: "integer", nullable: false),
                    seo_title = table.Column<string>(type: "text", nullable: false),
                    seo_description = table.Column<string>(type: "text", nullable: false),
                    seo_headerscript = table.Column<string>(type: "text", nullable: false),
                    seo_categorylowersubtitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.categoryexternalid);
                });

            migrationBuilder.CreateTable(
                name: "categoryproduct",
                columns: table => new
                {
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false),
                    productsku = table.Column<string>(type: "text", nullable: false),
                    productversionid = table.Column<long>(type: "bigint", nullable: false),
                    productcurrencycode = table.Column<string>(type: "text", nullable: false),
                    bestsellerssortposition = table.Column<int>(type: "integer", nullable: false),
                    onlinedatesortposition = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categoryproduct", x => new { x.sku, x.categoryid });
                    table.ForeignKey(
                        name: "fk_categoryproduct_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "categoryexternalid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_categoryproduct_products_productsku_productversionid_produc~",
                        columns: x => new { x.productsku, x.productversionid, x.productcurrencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "facet",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    fieldname = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_facet", x => x.id);
                    table.ForeignKey(
                        name: "fk_facet_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "categoryexternalid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seocategory",
                columns: table => new
                {
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    urlname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seocategory", x => new { x.categoryid, x.id });
                    table.ForeignKey(
                        name: "fk_seocategory_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "categoryexternalid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productfacet",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false),
                    fieldname = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productfacet", x => x.id);
                    table.ForeignKey(
                        name: "fk_productfacet_categoryproduct_sku_categoryid",
                        columns: x => new { x.sku, x.categoryid },
                        principalTable: "categoryproduct",
                        principalColumns: new[] { "sku", "categoryid" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productsincategories",
                columns: table => new
                {
                    sku = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productsincategories", x => new { x.categoryid, x.sku, x.versionid, x.currencycode });
                    table.ForeignKey(
                        name: "fk_productsincategories_categoryproduct_sku_categoryid",
                        columns: x => new { x.sku, x.categoryid },
                        principalTable: "categoryproduct",
                        principalColumns: new[] { "sku", "categoryid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productsincategories_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_categoryproduct_categoryid",
                table: "categoryproduct",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_categoryproduct_productsku_productversionid_productcurrency~",
                table: "categoryproduct",
                columns: new[] { "productsku", "productversionid", "productcurrencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_facet_categoryid",
                table: "facet",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_productfacet_sku_categoryid",
                table: "productfacet",
                columns: new[] { "sku", "categoryid" });

            migrationBuilder.CreateIndex(
                name: "ix_productsincategories_sku_categoryid",
                table: "productsincategories",
                columns: new[] { "sku", "categoryid" });

            migrationBuilder.CreateIndex(
                name: "ix_productsincategories_sku_versionid_currencycode",
                table: "productsincategories",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_seocategory_categoryid",
                table: "seocategory",
                column: "categoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facet");

            migrationBuilder.DropTable(
                name: "productfacet");

            migrationBuilder.DropTable(
                name: "productsincategories");

            migrationBuilder.DropTable(
                name: "seocategory");

            migrationBuilder.DropTable(
                name: "categoryproduct");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
