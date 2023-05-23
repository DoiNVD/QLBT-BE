using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCORE3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucDanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MustChangePass = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BoPhan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChucVu_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonViTraLuong_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "danhMucKhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaKho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKho = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhMucKhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_danhMucKhos_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_danhMucKhos_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "domains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDomain = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_domains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_domains_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonViTinhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDonViTinh = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonViTinhs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "donViTraLuongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDonViTraLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDonViTraLuong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donViTraLuongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_donViTraLuongs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "heThongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHeThong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHeThong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heThongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_heThongs_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "loaiThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaLoaiThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoaiThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loaiThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AccessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessdBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_AspNetUsers_AccessdBy",
                        column: x => x.AccessdBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenMenu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Parent_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNhaCungCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhaCungCaps_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nhoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNhom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenNhom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nhoms_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhanHois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDung_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDungPhanHoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GopY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiXuLy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanHois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanHois_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucDangNhaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenPhuongThucDangNhap = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LinkCheckLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucDangNhaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhuongThucDangNhaps_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tapDoans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaTapDoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenTapDoan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tapDoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tapDoans_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHangThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HeThong_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hangThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hangThietBis_heThongs_HeThong_Id",
                        column: x => x.HeThong_Id,
                        principalTable: "heThongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Roles",
                columns: table => new
                {
                    Menu_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    View = table.Column<bool>(type: "bit", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    Del = table.Column<bool>(type: "bit", nullable: false),
                    Cof = table.Column<bool>(type: "bit", nullable: false),
                    Print = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Roles", x => new { x.Menu_Id, x.Role_Id });
                    table.ForeignKey(
                        name: "FK_Menu_Roles_AspNetRoles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Roles_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Roles_Menus_Menu_Id",
                        column: x => x.Menu_Id,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonVis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDonVi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TapDoan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonVis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonVis_tapDoans_TapDoan_Id",
                        column: x => x.TapDoan_Id,
                        principalTable: "tapDoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "loaiHangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiHangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loaiHangThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loaiHangThietBis_hangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "hangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loaiHangThietBis_loaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "loaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "thongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaThongTinThietBi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenThietBi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CauHinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NhaCungCap_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoSeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBaoHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thongTinThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thongTinThietBis_NhaCungCaps_NhaCungCap_Id",
                        column: x => x.NhaCungCap_Id,
                        principalTable: "NhaCungCaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thongTinThietBis_domains_Domain_Id",
                        column: x => x.Domain_Id,
                        principalTable: "domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thongTinThietBis_hangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "hangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DanhMucKho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khos_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khos_DonViTinhs_DonViTinh_Id",
                        column: x => x.DonViTinh_Id,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khos_DonVis_DonVi_Id",
                        column: x => x.DonVi_Id,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khos_danhMucKhos_DanhMucKho_Id",
                        column: x => x.DanhMucKho_Id,
                        principalTable: "danhMucKhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "phongbans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaPhongBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DonVi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phongbans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phongbans_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_phongbans_DonVis_DonVi_Id",
                        column: x => x.DonVi_Id,
                        principalTable: "DonVis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chiTietLoaiThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietLoaiThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chiTietLoaiThongTinThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chiTietLoaiThongTinThietBis_loaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "loaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chiTietLoaiThongTinThietBis_thongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "thongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "loaiThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loaiThongTinThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loaiThongTinThietBis_loaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "loaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_loaiThongTinThietBis_thongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "thongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "thongTinHangThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HangThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongTinHangThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thongTinHangThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thongTinHangThietBis_hangThietBis_HangThietBi_Id",
                        column: x => x.HangThietBi_Id,
                        principalTable: "hangThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thongTinHangThietBis_thongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "thongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khoLoaiThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoLoaiThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khoLoaiThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoLoaiThietBis_khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoLoaiThietBis_loaiThietBis_LoaiThietBi_Id",
                        column: x => x.LoaiThietBi_Id,
                        principalTable: "loaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "khoThongTinThietBis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kho_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongTinThietBi_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoThongTinThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khoThongTinThietBis_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoThongTinThietBis_khos_Kho_Id",
                        column: x => x.Kho_Id,
                        principalTable: "khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_khoThongTinThietBis_thongTinThietBis_ThongTinThietBi_Id",
                        column: x => x.ThongTinThietBi_Id,
                        principalTable: "thongTinThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoPhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaBoPhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenBoPhan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhongBan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoPhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoPhans_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoPhans_phongbans_PhongBan_Id",
                        column: x => x.PhongBan_Id,
                        principalTable: "phongbans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BoPhan_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucVus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chucVus_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_chucVus_BoPhans_BoPhan_Id",
                        column: x => x.BoPhan_Id,
                        principalTable: "BoPhans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BoPhan_Id",
                table: "AspNetUsers",
                column: "BoPhan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChucVu_Id",
                table: "AspNetUsers",
                column: "ChucVu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonVi_Id",
                table: "AspNetUsers",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BoPhans_CreatedBy",
                table: "BoPhans",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BoPhans_PhongBan_Id",
                table: "BoPhans",
                column: "PhongBan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietLoaiThongTinThietBis_CreatedBy",
                table: "chiTietLoaiThongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietLoaiThongTinThietBis_LoaiThietBi_Id",
                table: "chiTietLoaiThongTinThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietLoaiThongTinThietBis_ThongTinThietBi_Id",
                table: "chiTietLoaiThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chucVus_BoPhan_Id",
                table: "chucVus",
                column: "BoPhan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chucVus_CreatedBy",
                table: "chucVus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_danhMucKhos_CreatedBy",
                table: "danhMucKhos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_danhMucKhos_User_Id",
                table: "danhMucKhos",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_domains_CreatedBy",
                table: "domains",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_CreatedBy",
                table: "DonVis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_TapDoan_Id",
                table: "DonVis",
                column: "TapDoan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DonViTinhs_CreatedBy",
                table: "DonViTinhs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_donViTraLuongs_CreatedBy",
                table: "donViTraLuongs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_hangThietBis_CreatedBy",
                table: "hangThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_hangThietBis_HeThong_Id",
                table: "hangThietBis",
                column: "HeThong_Id");

            migrationBuilder.CreateIndex(
                name: "IX_heThongs_CreatedBy",
                table: "heThongs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khoLoaiThietBis_CreatedBy",
                table: "khoLoaiThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khoLoaiThietBis_Kho_Id",
                table: "khoLoaiThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khoLoaiThietBis_LoaiThietBi_Id",
                table: "khoLoaiThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khos_CreatedBy",
                table: "khos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khos_DanhMucKho_Id",
                table: "khos",
                column: "DanhMucKho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khos_DonVi_Id",
                table: "khos",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khos_DonViTinh_Id",
                table: "khos",
                column: "DonViTinh_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khos_UserId",
                table: "khos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_khoThongTinThietBis_CreatedBy",
                table: "khoThongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_khoThongTinThietBis_Kho_Id",
                table: "khoThongTinThietBis",
                column: "Kho_Id");

            migrationBuilder.CreateIndex(
                name: "IX_khoThongTinThietBis_ThongTinThietBi_Id",
                table: "khoThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_loaiHangThietBis_CreatedBy",
                table: "loaiHangThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_loaiHangThietBis_HangThietBi_Id",
                table: "loaiHangThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_loaiHangThietBis_LoaiThietBi_Id",
                table: "loaiHangThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_loaiThietBis_CreatedBy",
                table: "loaiThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_loaiThongTinThietBis_CreatedBy",
                table: "loaiThongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_loaiThongTinThietBis_LoaiThietBi_Id",
                table: "loaiThongTinThietBis",
                column: "LoaiThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_loaiThongTinThietBis_ThongTinThietBi_Id",
                table: "loaiThongTinThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_AccessdBy",
                table: "Logs",
                column: "AccessdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Roles_CreatedBy",
                table: "Menu_Roles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Roles_Role_Id",
                table: "Menu_Roles",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CreatedBy",
                table: "Menus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_CreatedBy",
                table: "NhaCungCaps",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Nhoms_CreatedBy",
                table: "Nhoms",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHois_CreatedBy",
                table: "PhanHois",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_phongbans_CreatedBy",
                table: "phongbans",
                column: "CreatedBy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phongbans_DonVi_Id",
                table: "phongbans",
                column: "DonVi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongThucDangNhaps_CreatedBy",
                table: "PhuongThucDangNhaps",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tapDoans_CreatedBy",
                table: "tapDoans",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinHangThietBis_CreatedBy",
                table: "thongTinHangThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinHangThietBis_HangThietBi_Id",
                table: "thongTinHangThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinHangThietBis_ThongTinThietBi_Id",
                table: "thongTinHangThietBis",
                column: "ThongTinThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinThietBis_CreatedBy",
                table: "thongTinThietBis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinThietBis_Domain_Id",
                table: "thongTinThietBis",
                column: "Domain_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinThietBis_HangThietBi_Id",
                table: "thongTinThietBis",
                column: "HangThietBi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thongTinThietBis_NhaCungCap_Id",
                table: "thongTinThietBis",
                column: "NhaCungCap_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BoPhans_BoPhan_Id",
                table: "AspNetUsers",
                column: "BoPhan_Id",
                principalTable: "BoPhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DonVis_DonVi_Id",
                table: "AspNetUsers",
                column: "DonVi_Id",
                principalTable: "DonVis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_chucVus_ChucVu_Id",
                table: "AspNetUsers",
                column: "ChucVu_Id",
                principalTable: "chucVus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_donViTraLuongs_DonViTraLuong_Id",
                table: "AspNetUsers",
                column: "DonViTraLuong_Id",
                principalTable: "donViTraLuongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoPhans_AspNetUsers_CreatedBy",
                table: "BoPhans");

            migrationBuilder.DropForeignKey(
                name: "FK_chucVus_AspNetUsers_CreatedBy",
                table: "chucVus");

            migrationBuilder.DropForeignKey(
                name: "FK_DonVis_AspNetUsers_CreatedBy",
                table: "DonVis");

            migrationBuilder.DropForeignKey(
                name: "FK_donViTraLuongs_AspNetUsers_CreatedBy",
                table: "donViTraLuongs");

            migrationBuilder.DropForeignKey(
                name: "FK_phongbans_AspNetUsers_CreatedBy",
                table: "phongbans");

            migrationBuilder.DropForeignKey(
                name: "FK_tapDoans_AspNetUsers_CreatedBy",
                table: "tapDoans");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "chiTietLoaiThongTinThietBis");

            migrationBuilder.DropTable(
                name: "khoLoaiThietBis");

            migrationBuilder.DropTable(
                name: "khoThongTinThietBis");

            migrationBuilder.DropTable(
                name: "loaiHangThietBis");

            migrationBuilder.DropTable(
                name: "loaiThongTinThietBis");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Menu_Roles");

            migrationBuilder.DropTable(
                name: "Nhoms");

            migrationBuilder.DropTable(
                name: "PhanHois");

            migrationBuilder.DropTable(
                name: "PhuongThucDangNhaps");

            migrationBuilder.DropTable(
                name: "thongTinHangThietBis");

            migrationBuilder.DropTable(
                name: "khos");

            migrationBuilder.DropTable(
                name: "loaiThietBis");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "thongTinThietBis");

            migrationBuilder.DropTable(
                name: "DonViTinhs");

            migrationBuilder.DropTable(
                name: "danhMucKhos");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");

            migrationBuilder.DropTable(
                name: "domains");

            migrationBuilder.DropTable(
                name: "hangThietBis");

            migrationBuilder.DropTable(
                name: "heThongs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "chucVus");

            migrationBuilder.DropTable(
                name: "donViTraLuongs");

            migrationBuilder.DropTable(
                name: "BoPhans");

            migrationBuilder.DropTable(
                name: "phongbans");

            migrationBuilder.DropTable(
                name: "DonVis");

            migrationBuilder.DropTable(
                name: "tapDoans");
        }
    }
}
