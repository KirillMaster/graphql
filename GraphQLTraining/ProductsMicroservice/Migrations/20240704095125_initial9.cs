using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class initial9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_productfacets_fieldname_value",
                table: "productfacets",
                columns: new[] { "fieldname", "value" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_productfacets_fieldname_value",
                table: "productfacets");
        }
    }
}
