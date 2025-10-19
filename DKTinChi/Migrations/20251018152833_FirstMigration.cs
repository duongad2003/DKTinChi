using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DKTinChi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    IdSinhVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.IdSinhVien);
                });

            migrationBuilder.CreateTable(
                name: "TinChis",
                columns: table => new
                {
                    IdTinChi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinChis", x => x.IdTinChi);
                });

            migrationBuilder.CreateTable(
                name: "DangKys",
                columns: table => new
                {
                    IdDangKy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSinhVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdTinChi = table.Column<int>(type: "int", nullable: false),
                    SoTinDaDangKy = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKys", x => x.IdDangKy);
                    table.ForeignKey(
                        name: "FK_DangKys_SinhViens_IdSinhVien",
                        column: x => x.IdSinhVien,
                        principalTable: "SinhViens",
                        principalColumn: "IdSinhVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKys_TinChis_IdTinChi",
                        column: x => x.IdTinChi,
                        principalTable: "TinChis",
                        principalColumn: "IdTinChi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangKys_IdSinhVien",
                table: "DangKys",
                column: "IdSinhVien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKys_IdTinChi",
                table: "DangKys",
                column: "IdTinChi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangKys");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "TinChis");
        }
    }
}
