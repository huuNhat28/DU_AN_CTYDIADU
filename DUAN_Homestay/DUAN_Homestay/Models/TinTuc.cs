using System.ComponentModel.DataAnnotations;

namespace DUAN_Homestay.Models
{
    public class TinTuc
    {
        [Key]
        public String MaTinTuc { get; set; }
        [Required]
        public String TieuDe { get; set; }
        [Required]
        public String NoiDung { get; set; }
        [Required]
        [StringLength(100)]
        public String HinhAnh { get; set; }
        [Required]
        public String LoaiTin { get; set; }
        [Required]
        public DateTime NgayDang { get; set; }
        [Required]
        public DateTime NgayCapNhat { get; set; }
        [Required]
        public bool HienThi { get; set; }

    }
}
