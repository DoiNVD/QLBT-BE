using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NETCORE3.Models
{
    public class TinhTrangBaoTri : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaTinhTrangBaoTri { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string TenTinhTrangBaoTri { get; set; }

        /*[ForeignKey("ThucHienBaoTri")]
        public Guid? ThucHienBaoTri_id { get; set; }
        public ThucHienBaoTri ThucHienBaoTri { get; set; }
        [ForeignKey("ChuyenNgayBaoTri")]
        public Guid? ChuyenNgayBaoTri_id { get; set; }
        public ChuyenNgayBaoTri ChuyenNgayBaoTri { get; set; }
        [ForeignKey("TieuChuanBaoTri")]
        public Guid? HuyBaoTri_id { get; set; }
        public HuyBaoTri HuyBaoTri { get; set; }*/
    }
}