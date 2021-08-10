using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Brand.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "brand");

            migrationBuilder.CreateTable(
                name: "brand",
                schema: "brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("brandBrandPK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "size",
                schema: "brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rusSize = table.Column<string>(type: "text", nullable: true),
                    brandSize = table.Column<string>(type: "text", nullable: true),
                    brandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("brandSizePK", x => x.id);
                    table.ForeignKey(
                        name: "FK_size_brand_brandId",
                        column: x => x.brandId,
                        principalSchema: "brand",
                        principalTable: "brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_size_brandId",
                schema: "brand",
                table: "size",
                column: "brandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "size",
                schema: "brand");

            migrationBuilder.DropTable(
                name: "brand",
                schema: "brand");
        }
    }
}
