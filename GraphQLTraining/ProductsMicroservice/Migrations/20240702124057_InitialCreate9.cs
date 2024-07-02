using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
