using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class updateThietBiSuaChuaVSLoiThietBiSuaChua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thietbisuachuas_Lois_MaLoi_id",
                table: "thietbisuachuas");

            migrationBuilder.DropColumn(
                name: "TenThietBiSuaChua",
                table: "thietbisuachuas");

            migrationBuilder.RenameColumn(
                name: "MaLoi_id",
                table: "thietbisuachuas",
                newName: "ThongTinThietBi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_thietbisuachuas_MaLoi_id",
                table: "thietbisuachuas",
                newName: "IX_thietbisuachuas_ThongTinThietBi_Id");

            migrationBuilder.CreateTable(
                name: "loithietbisuachuas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoiThietBiSuaChua_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThietBiSuaChua_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_loithietbisuachuas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loithietbisuachuas_AspNetUsers_User_CreatedId",
                        column: x => x.User_CreatedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loithietbisuachuas_Lois_LoiThietBiSuaChua_Id",
                        column: x => x.LoiThietBiSuaChua_Id,
                        principalTable: "Lois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loithietbisuachuas_thietbisuachuas_ThietBiSuaChua_Id",
                        column: x => x.ThietBiSuaChua_Id,
                        principalTable: "thietbisuachuas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_loithietbisuachuas_LoiThietBiSuaChua_Id",
                table: "loithietbisuachuas",
                column: "LoiThietBiSuaChua_Id");

            migrationBuilder.CreateIndex(
                name: "IX_loithietbisuachuas_ThietBiSuaChua_Id",
                table: "loithietbisuachuas",
                column: "ThietBiSuaChua_Id");

            migrationBuilder.CreateIndex(
                name: "IX_loithietbisuachuas_User_CreatedId",
                table: "loithietbisuachuas",
                column: "User_CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_thietbisuachuas_thongTinThietBis_ThongTinThietBi_Id",
                table: "thietbisuachuas",
                column: "ThongTinThietBi_Id",
                principalTable: "thongTinThietBis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thietbisuachuas_thongTinThietBis_ThongTinThietBi_Id",
                table: "thietbisuachuas");

            migrationBuilder.DropTable(
                name: "loithietbisuachuas");

            migrationBuilder.RenameColumn(
                name: "ThongTinThietBi_Id",
                table: "thietbisuachuas",
                newName: "MaLoi_id");

            migrationBuilder.RenameIndex(
                name: "IX_thietbisuachuas_ThongTinThietBi_Id",
                table: "thietbisuachuas",
                newName: "IX_thietbisuachuas_MaLoi_id");

            migrationBuilder.AddColumn<string>(
                name: "TenThietBiSuaChua",
                table: "thietbisuachuas",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_thietbisuachuas_Lois_MaLoi_id",
                table: "thietbisuachuas",
                column: "MaLoi_id",
                principalTable: "Lois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
