using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class ThucHienBaoTri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lois_AspNetUsers_User_CreatedId",
                table: "Lois");

            migrationBuilder.DropForeignKey(
                name: "FK_loithietbisuachuas_Lois_Loi_Id",
                table: "loithietbisuachuas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lois",
                table: "Lois");

            migrationBuilder.RenameTable(
                name: "Lois",
                newName: "lois");

            migrationBuilder.RenameIndex(
                name: "IX_Lois_User_CreatedId",
                table: "lois",
                newName: "IX_lois_User_CreatedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lois",
                table: "lois",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "thucHienBaoTris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaThucHienBaoTri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThoiGianBatDauBaoTri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuChuanBaoTri_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThietBiSuaChua_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhGiaNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thucHienBaoTris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thucHienBaoTris_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thucHienBaoTris_thietbisuachuas_ThietBiSuaChua_Id",
                        column: x => x.ThietBiSuaChua_Id,
                        principalTable: "thietbisuachuas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thucHienBaoTris_tieuChuanBaoTris_TieuChuanBaoTri_Id",
                        column: x => x.TieuChuanBaoTri_Id,
                        principalTable: "tieuChuanBaoTris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_thucHienBaoTris_ThietBiSuaChua_Id",
                table: "thucHienBaoTris",
                column: "ThietBiSuaChua_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thucHienBaoTris_TieuChuanBaoTri_Id",
                table: "thucHienBaoTris",
                column: "TieuChuanBaoTri_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thucHienBaoTris_User_CreatedId",
                table: "thucHienBaoTris",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_lois_AspNetUsers_User_CreatedId",
                table: "lois",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loithietbisuachuas_lois_Loi_Id",
                table: "loithietbisuachuas",
                column: "Loi_Id",
                principalTable: "lois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lois_AspNetUsers_User_CreatedId",
                table: "lois");

            migrationBuilder.DropForeignKey(
                name: "FK_loithietbisuachuas_lois_Loi_Id",
                table: "loithietbisuachuas");

            migrationBuilder.DropTable(
                name: "thucHienBaoTris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lois",
                table: "lois");

            migrationBuilder.RenameTable(
                name: "lois",
                newName: "Lois");

            migrationBuilder.RenameIndex(
                name: "IX_lois_User_CreatedId",
                table: "Lois",
                newName: "IX_Lois_User_CreatedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lois",
                table: "Lois",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lois_AspNetUsers_User_CreatedId",
                table: "Lois",
                column: "User_CreatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_loithietbisuachuas_Lois_Loi_Id",
                table: "loithietbisuachuas",
                column: "Loi_Id",
                principalTable: "Lois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
