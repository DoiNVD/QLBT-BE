using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NETCORE3.Models
{
    public class ThucHienBaoTri : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaThucHienBaoTri { get; set; }
        public DateTime ThoiGianBatDauBaoTri { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string HinhAnh { get; set; }
        [ForeignKey("TieuChuanBaoTri")]
        public Guid? TieuChuanBaoTri_Id { get; set; }
        public TieuChuanBaoTri TieuChuanBaoTri { get; set; }
        [ForeignKey("ThietBiSuaChua")]
        public Guid? ThietBiSuaChua_Id { get; set; }
        public ThietBiSuaChua ThietBiSuaChua { get; set; }
        public string GhiChu { get; set; }
        public string DanhGiaNguoiDung { get; set; }
    }
}