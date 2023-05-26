using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NETCORE3.Models
{
    public class TieuChuanBaoTri : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaTieuChuan { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Tên bắt buộc")]
        public string TenTieuChuan { get; set; }
        public DateTime ThoiGian { get; set; }
        public string KyHieuBaoTri { get; set; }
        public string QuyDinhTaiLieuHuongDan { get; set; }
        
    }
}