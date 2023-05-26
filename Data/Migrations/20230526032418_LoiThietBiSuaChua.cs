using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class LoiThietBiSuaChua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loithietbisuachuas_Lois_LoiThietBiSuaChua_Id",
                table: "loithietbisuachuas");

            migrationBuilder.RenameColumn(
                name: "LoiThietBiSuaChua_Id",
                table: "loithietbisuachuas",
                newName: "Loi_Id");

            migrationBuilder.RenameIndex(
                name: "IX_loithietbisuachuas_LoiThietBiSuaChua_Id",
                table: "loithietbisuachuas",
                newName: "IX_loithietbisuachuas_Loi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_loithietbisuachuas_Lois_Loi_Id",
                table: "loithietbisuachuas",
                column: "Loi_Id",
                principalTable: "Lois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loithietbisuachuas_Lois_Loi_Id",
                table: "loithietbisuachuas");

            migrationBuilder.RenameColumn(
                name: "Loi_Id",
                table: "loithietbisuachuas",
                newName: "LoiThietBiSuaChua_Id");

            migrationBuilder.RenameIndex(
                name: "IX_loithietbisuachuas_Loi_Id",
                table: "loithietbisuachuas",
                newName: "IX_loithietbisuachuas_LoiThietBiSuaChua_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_loithietbisuachuas_Lois_LoiThietBiSuaChua_Id",
                table: "loithietbisuachuas",
                column: "LoiThietBiSuaChua_Id",
                principalTable: "Lois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
