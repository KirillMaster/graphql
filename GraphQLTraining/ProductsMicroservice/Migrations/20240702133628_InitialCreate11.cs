using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ribbon_products_productsku_productversionid_productcurrency~",
                table: "ribbon");

            migrationBuilder.DropIndex(
                name: "ix_ribbon_productsku_productversionid_productcurrencycode",
                table: "ribbon");

            migrationBuilder.DropColumn(
                name: "productcurrencycode",
                table: "ribbon");

            migrationBuilder.DropColumn(
                name: "productsku",
                table: "ribbon");

            migrationBuilder.DropColumn(
                name: "productversionid",
                table: "ribbon");

            migrationBuilder.AddColumn<int>(
                name: "media_defaultitemid",
                table: "products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "media_overlayitemid",
                table: "products",
                type: "integer",
                nullable: true);

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
                    cdnimages_id = table.Column<int>(type: "integer", nullable: true),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "digitalasset");

            migrationBuilder.DropColumn(
                name: "media_defaultitemid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "media_overlayitemid",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "productcurrencycode",
                table: "ribbon",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "productsku",
                table: "ribbon",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "productversionid",
                table: "ribbon",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_ribbon_productsku_productversionid_productcurrencycode",
                table: "ribbon",
                columns: new[] { "productsku", "productversionid", "productcurrencycode" });

            migrationBuilder.AddForeignKey(
                name: "fk_ribbon_products_productsku_productversionid_productcurrency~",
                table: "ribbon",
                columns: new[] { "productsku", "productversionid", "productcurrencycode" },
                principalTable: "products",
                principalColumns: new[] { "sku", "versionid", "currencycode" });
        }
    }
}
