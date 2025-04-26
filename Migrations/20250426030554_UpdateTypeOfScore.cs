using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTypeOfScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hinhthucthanhtoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HinhThucThanhToan = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinhthucthanhtoans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phongtros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_hinh_thuc_thanh_toan = table.Column<int>(type: "integer", nullable: false),
                    TenNguoiThue = table.Column<string>(type: "text", nullable: false),
                    SDT = table.Column<string>(type: "text", nullable: false),
                    NgayThue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GhiChu = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phongtros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phongtros_Hinhthucthanhtoans_id_hinh_thuc_thanh_toan",
                        column: x => x.id_hinh_thuc_thanh_toan,
                        principalTable: "Hinhthucthanhtoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phongtros_id_hinh_thuc_thanh_toan",
                table: "phongtros",
                column: "id_hinh_thuc_thanh_toan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "phongtros");

            migrationBuilder.DropTable(
                name: "Hinhthucthanhtoans");
        }
    }
}
