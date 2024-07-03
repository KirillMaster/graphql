using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
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
                    table.PrimaryKey("pk_categories", x => x.categoryexternalid);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    sku = table.Column<string>(type: "text", nullable: false),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    updatedat = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    onlinedate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    url = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    site_id = table.Column<int>(type: "integer", nullable: false),
                    site_name = table.Column<string>(type: "text", nullable: false),
                    site_currency_code = table.Column<string>(type: "text", nullable: false),
                    site_currency_symbol = table.Column<string>(type: "text", nullable: false),
                    site_currency_side = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    instruction = table.Column<string>(type: "text", nullable: false),
                    isoutofstock = table.Column<bool>(type: "boolean", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    pricing_priceelements = table.Column<string>(type: "text", nullable: false),
                    pricing_sellingprice = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing_crossedprice = table.Column<decimal>(type: "numeric", nullable: true),
                    pricing_discountpercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    pricing_baseprice = table.Column<decimal>(type: "numeric", nullable: true),
                    pricing_supplierprice = table.Column<decimal>(type: "numeric", nullable: true),
                    metadata_schemaversion = table.Column<string>(type: "text", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    isdiamond = table.Column<bool>(type: "boolean", nullable: false),
                    media_defaultitemid = table.Column<int>(type: "integer", nullable: true),
                    media_overlayitemid = table.Column<int>(type: "integer", nullable: true),
                    upperdescription = table.Column<string>(type: "text", nullable: true),
                    usefriendlyurl = table.Column<bool>(type: "boolean", nullable: true),
                    friendlyurl = table.Column<string>(type: "text", nullable: true),
                    noindex = table.Column<bool>(type: "boolean", nullable: true),
                    excludedcountries = table.Column<string[]>(type: "text[]", nullable: true),
                    id = table.Column<int>(type: "integer", nullable: false),
                    shortid = table.Column<int>(type: "integer", nullable: false),
                    family = table.Column<string>(type: "jsonb", nullable: false),
                    productioninfo = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => new { x.sku, x.versionid, x.currencycode });
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
                        name: "fk_facet_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
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
                        name: "fk_seocategory_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "categoryexternalid",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "fk_categoryproduct_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
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
                name: "digitalasset",
                columns: table => new
                {
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order = table.Column<int>(type: "integer", nullable: false),
                    alt = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    cdnimages_original_width = table.Column<int>(type: "integer", nullable: true),
                    cdnimages_original_height = table.Column<int>(type: "integer", nullable: true),
                    cdnimages_original_path = table.Column<string>(type: "text", nullable: true),
                    cdnimages_medium_width = table.Column<int>(type: "integer", nullable: true),
                    cdnimages_medium_height = table.Column<int>(type: "integer", nullable: true),
                    cdnimages_medium_path = table.Column<string>(type: "text", nullable: true),
                    wistiavideo_key = table.Column<string>(type: "text", nullable: true),
                    threesixtywistiavideo_key = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_digitalasset", x => new { x.sku, x.versionid, x.currencycode, x.id });
                    table.ForeignKey(
                        name: "fk_digitalasset_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "field",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_field", x => x.id);
                    table.ForeignKey(
                        name: "fk_field_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productcategory",
                columns: table => new
                {
                    uid = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    cartname = table.Column<string>(type: "text", nullable: false),
                    englishname = table.Column<string>(type: "text", nullable: false),
                    englishcartname = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    isrequired = table.Column<bool>(type: "boolean", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    displaytype = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: false),
                    textminlength = table.Column<int>(type: "integer", nullable: true),
                    textismultiline = table.Column<bool>(type: "boolean", nullable: false),
                    textmaxlength = table.Column<int>(type: "integer", nullable: true),
                    textplaceholder = table.Column<string>(type: "text", nullable: true),
                    tooltipid = table.Column<int>(type: "integer", nullable: true),
                    glossaryid = table.Column<int>(type: "integer", nullable: true),
                    customizationtemplate_url = table.Column<string>(type: "text", nullable: true),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productcategory", x => x.uid);
                    table.ForeignKey(
                        name: "fk_productcategory_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "relationship",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_relationship", x => x.id);
                    table.ForeignKey(
                        name: "fk_relationship_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "showandhide",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    controllingcategory = table.Column<int>(type: "integer", nullable: false),
                    controllingcategorykey = table.Column<string>(type: "text", nullable: false),
                    controllingoption = table.Column<int>(type: "integer", nullable: false),
                    controlledcategories = table.Column<List<int>>(type: "integer[]", nullable: false),
                    controlledcategorykeys = table.Column<List<string>>(type: "text[]", nullable: false),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_showandhide", x => x.id);
                    table.ForeignKey(
                        name: "fk_showandhide_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
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

            migrationBuilder.CreateTable(
                name: "label",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    categoryuid = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_label", x => new { x.id, x.categoryuid });
                    table.ForeignKey(
                        name: "fk_label_productcategory_categoryuid",
                        column: x => x.categoryuid,
                        principalTable: "productcategory",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "option",
                columns: table => new
                {
                    categoryuid = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    cartname = table.Column<string>(type: "text", nullable: false),
                    englishname = table.Column<string>(type: "text", nullable: false),
                    englishcartname = table.Column<string>(type: "text", nullable: false),
                    isdefault = table.Column<bool>(type: "boolean", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false),
                    isplaceholder = table.Column<bool>(type: "boolean", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    priceadjustment = table.Column<decimal>(type: "numeric", nullable: false),
                    usepriceadjustmentinname = table.Column<bool>(type: "boolean", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    relatedproduct_id = table.Column<int>(type: "integer", nullable: true),
                    relatedproduct_shortid = table.Column<int>(type: "integer", nullable: true),
                    relatedproduct_sku = table.Column<string>(type: "text", nullable: true),
                    relatedproduct_pricing_price = table.Column<decimal>(type: "numeric", nullable: true),
                    relatedproduct_pricing_pricingtype = table.Column<string>(type: "text", nullable: true),
                    relatedproduct_excludedcountries = table.Column<string[]>(type: "text[]", nullable: true),
                    relatedproduct_friendlyurl = table.Column<string>(type: "text", nullable: true),
                    cartdisplaytype = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_option", x => new { x.id, x.categoryuid });
                    table.ForeignKey(
                        name: "fk_option_productcategory_categoryuid",
                        column: x => x.categoryuid,
                        principalTable: "productcategory",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "relationshipproduct",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    relationshipid = table.Column<int>(type: "integer", nullable: false),
                    relatedcategoryuids = table.Column<List<string>>(type: "text[]", nullable: false),
                    relatedchildcategoryuids = table.Column<List<string>>(type: "text[]", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    usefriendlyurl = table.Column<bool>(type: "boolean", nullable: true),
                    friendlyurl = table.Column<string>(type: "text", nullable: true),
                    shortid = table.Column<int>(type: "integer", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_relationshipproduct", x => x.id);
                    table.ForeignKey(
                        name: "fk_relationshipproduct_relationship_relationshipid",
                        column: x => x.relationshipid,
                        principalTable: "relationship",
                        principalColumn: "id",
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
                name: "ix_digitalasset_sku_versionid_currencycode",
                table: "digitalasset",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_facet_categoryid",
                table: "facet",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_facet_fieldname",
                table: "facet",
                column: "fieldname");

            migrationBuilder.CreateIndex(
                name: "ix_field_sku_versionid_currencycode",
                table: "field",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_label_categoryuid",
                table: "label",
                column: "categoryuid");

            migrationBuilder.CreateIndex(
                name: "ix_option_categoryuid",
                table: "option",
                column: "categoryuid");

            migrationBuilder.CreateIndex(
                name: "ix_productcategory_sku_versionid_currencycode",
                table: "productcategory",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_productcategory_uid",
                table: "productcategory",
                column: "uid");

            migrationBuilder.CreateIndex(
                name: "ix_productfacet_fieldname",
                table: "productfacet",
                column: "fieldname");

            migrationBuilder.CreateIndex(
                name: "ix_productfacet_sku_categoryid",
                table: "productfacet",
                columns: new[] { "sku", "categoryid" });

            migrationBuilder.CreateIndex(
                name: "ix_products_sku",
                table: "products",
                column: "sku");

            migrationBuilder.CreateIndex(
                name: "ix_products_sku_versionid_currencycode",
                table: "products",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_productsincategories_sku_categoryid",
                table: "productsincategories",
                columns: new[] { "sku", "categoryid" });

            migrationBuilder.CreateIndex(
                name: "ix_productsincategories_sku_versionid_currencycode",
                table: "productsincategories",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_relationship_sku_versionid_currencycode",
                table: "relationship",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_relationshipproduct_relationshipid",
                table: "relationshipproduct",
                column: "relationshipid");

            migrationBuilder.CreateIndex(
                name: "ix_seocategory_categoryid",
                table: "seocategory",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_showandhide_sku_versionid_currencycode",
                table: "showandhide",
                columns: new[] { "sku", "versionid", "currencycode" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "digitalasset");

            migrationBuilder.DropTable(
                name: "facet");

            migrationBuilder.DropTable(
                name: "field");

            migrationBuilder.DropTable(
                name: "label");

            migrationBuilder.DropTable(
                name: "option");

            migrationBuilder.DropTable(
                name: "productfacet");

            migrationBuilder.DropTable(
                name: "productsincategories");

            migrationBuilder.DropTable(
                name: "relationshipproduct");

            migrationBuilder.DropTable(
                name: "seocategory");

            migrationBuilder.DropTable(
                name: "showandhide");

            migrationBuilder.DropTable(
                name: "productcategory");

            migrationBuilder.DropTable(
                name: "categoryproduct");

            migrationBuilder.DropTable(
                name: "relationship");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
