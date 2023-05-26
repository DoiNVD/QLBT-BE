using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NETCORE3.Models
{
    public class ThietBiSuaChua : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaThietBiSuaChua { get; set; }
        [ForeignKey("ThongTinThietBi")]
        public Guid? ThongTinThietBi_Id { get; set; }
        //sử dụng để goi hàm khi lấy mqh 1;1
        public ThongTinThietBi ThongTinThietBi { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }
        [ForeignKey("DonViTinh")]
        public Guid? DonViTinh_Id { get; set; }
        //sử dụng để goi hàm khi lấy mqh 1;1
        public DonViTinh DonViTinh { get; set; }
        [JsonIgnore]
        public virtual ICollection<LoiThietBiSuaChua> loiThietBiSuaChuas { get; set; }
        [NotMapped]
        public List<LoiThietBiSuaChua> lstLois { get; set; }

    }
}