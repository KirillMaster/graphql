using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    uid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    updatedat = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    onlinedate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    family_id = table.Column<int>(type: "integer", nullable: false),
                    family_name = table.Column<string>(type: "text", nullable: false),
                    productioninfo_isnonenglishinscription = table.Column<bool>(type: "boolean", nullable: true),
                    productioninfo_boxsize_id = table.Column<int>(type: "integer", nullable: true),
                    productioninfo_boxsize_name = table.Column<string>(type: "text", nullable: true),
                    productioninfo_weight = table.Column<decimal>(type: "numeric", nullable: true),
                    productioninfo_productsizehscode_id = table.Column<int>(type: "integer", nullable: true),
                    productioninfo_productsizehscode_name = table.Column<string>(type: "text", nullable: true),
                    productioninfo_productsize = table.Column<string>(type: "text", nullable: true),
                    productioninfo_supplierproductid = table.Column<string>(type: "text", nullable: true),
                    productioninfo_supplierid = table.Column<int>(type: "integer", nullable: true),
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
                    sku = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "category",
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
                    productuid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.uid);
                    table.ForeignKey(
                        name: "fk_category_products_productuid",
                        column: x => x.productuid,
                        principalTable: "products",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "digitalasset",
                columns: table => new
                {
                    productuid = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("pk_digitalasset", x => new { x.productuid, x.id });
                    table.ForeignKey(
                        name: "fk_digitalasset_products_productuid",
                        column: x => x.productuid,
                        principalTable: "products",
                        principalColumn: "uid",
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
                    productuid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_field", x => x.id);
                    table.ForeignKey(
                        name: "fk_field_products_productuid",
                        column: x => x.productuid,
                        principalTable: "products",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "relationship",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false),
                    productuid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_relationship", x => x.id);
                    table.ForeignKey(
                        name: "fk_relationship_products_productuid",
                        column: x => x.productuid,
                        principalTable: "products",
                        principalColumn: "uid",
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
                    productuid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_showandhide", x => x.id);
                    table.ForeignKey(
                        name: "fk_showandhide_products_productuid",
                        column: x => x.productuid,
                        principalTable: "products",
                        principalColumn: "uid",
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
                        name: "fk_label_category_categoryuid",
                        column: x => x.categoryuid,
                        principalTable: "category",
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
                        name: "fk_option_category_categoryuid",
                        column: x => x.categoryuid,
                        principalTable: "category",
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
                name: "ix_category_productuid",
                table: "category",
                column: "productuid");

            migrationBuilder.CreateIndex(
                name: "ix_category_uid",
                table: "category",
                column: "uid");

            migrationBuilder.CreateIndex(
                name: "ix_digitalasset_productuid",
                table: "digitalasset",
                column: "productuid");

            migrationBuilder.CreateIndex(
                name: "ix_field_productuid",
                table: "field",
                column: "productuid");

            migrationBuilder.CreateIndex(
                name: "ix_label_categoryuid",
                table: "label",
                column: "categoryuid");

            migrationBuilder.CreateIndex(
                name: "ix_option_categoryuid",
                table: "option",
                column: "categoryuid");

            migrationBuilder.CreateIndex(
                name: "ix_products_sku",
                table: "products",
                column: "sku");

            migrationBuilder.CreateIndex(
                name: "ix_products_sku_versionid_currencycode",
                table: "products",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_products_uid",
                table: "products",
                column: "uid");

            migrationBuilder.CreateIndex(
                name: "ix_relationship_productuid",
                table: "relationship",
                column: "productuid");

            migrationBuilder.CreateIndex(
                name: "ix_relationshipproduct_relationshipid",
                table: "relationshipproduct",
                column: "relationshipid");

            migrationBuilder.CreateIndex(
                name: "ix_showandhide_productuid",
                table: "showandhide",
                column: "productuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "digitalasset");

            migrationBuilder.DropTable(
                name: "field");

            migrationBuilder.DropTable(
                name: "label");

            migrationBuilder.DropTable(
                name: "option");

            migrationBuilder.DropTable(
                name: "relationshipproduct");

            migrationBuilder.DropTable(
                name: "showandhide");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "relationship");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
