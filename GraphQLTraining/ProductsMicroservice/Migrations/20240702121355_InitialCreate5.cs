using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ribbon",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    currencycode = table.Column<string>(type: "text", nullable: false),
                    versionid = table.Column<long>(type: "bigint", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ribbon", x => x.id);
                    table.ForeignKey(
                        name: "fk_ribbon_products_sku_versionid_currencycode",
                        columns: x => new { x.sku, x.versionid, x.currencycode },
                        principalTable: "products",
                        principalColumns: new[] { "sku", "versionid", "currencycode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_products_sku_versionid_currencycode",
                table: "products",
                columns: new[] { "sku", "versionid", "currencycode" });

            migrationBuilder.CreateIndex(
                name: "ix_ribbon_sku_currencycode_versionid",
                table: "ribbon",
                columns: new[] { "sku", "currencycode", "versionid" });

            migrationBuilder.CreateIndex(
                name: "ix_ribbon_sku_versionid_currencycode",
                table: "ribbon",
                columns: new[] { "sku", "versionid", "currencycode" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ribbon");

            migrationBuilder.DropIndex(
                name: "ix_products_sku_versionid_currencycode",
                table: "products");
        }
    }
}
