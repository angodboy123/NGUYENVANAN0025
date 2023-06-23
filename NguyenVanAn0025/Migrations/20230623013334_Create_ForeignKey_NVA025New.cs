using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenVanAn0025.Migrations
{
    /// <inheritdoc />
    public partial class Create_ForeignKey_NVA025New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NVA025New",
                columns: table => new
                {
                    NewID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NewMa = table.Column<string>(type: "TEXT", nullable: true),
                    TenSanPham = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVA025New", x => x.NewID);
                    table.ForeignKey(
                        name: "FK_NVA025New_SanPham_TenSanPham",
                        column: x => x.TenSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NVA025New_TenSanPham",
                table: "NVA025New",
                column: "TenSanPham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NVA025New");
        }
    }
}
