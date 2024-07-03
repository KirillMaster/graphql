using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productsincategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productsincategories",
                columns: table => new
                {
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    currencycode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productsincategories", x => new { x.categoryid, x.sku, x.versionid, x.currencycode });
                    table.ForeignKey(
                        name: "fk_productsincategories_categoryproduct_sku_categoryid",
                        columns: x => new { x.sku, x.categoryid },
                        principalTable: "categoryproduct",
                        principalColumns: new[] { "productsku", "categoryid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productsincategories_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_productsincategories_sku_categoryid",
                table: "productsincategories",
                columns: new[] { "sku", "categoryid" });

            migrationBuilder.CreateIndex(
                name: "ix_productsincategories_sku_versionid_currencycode",
                table: "productsincategories",
                columns: new[] { "sku", "versionid", "currencycode" });
        }
    }
}
