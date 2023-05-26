using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class ChuyenNgayBaoTri : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaChuyenNgayBaoTri { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Lý do bắt buộc")]
        public string LyDoChuyen { get; set; }

        [Required(ErrorMessage = "Ngày chuyển bắt buộc")]
        public DateTime NgayChuyen { get; set; }

       
    }
}