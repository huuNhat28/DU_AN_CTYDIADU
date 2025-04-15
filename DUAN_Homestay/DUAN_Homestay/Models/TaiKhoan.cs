using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUAN_Homestay.Models
{
    public class TaiKhoan
    {
        [Key]
        public String MaTaiKhoan { get; set; }
        [Required]
        public String TenDangNhap { get; set; }
        [Required]
        public String MatKhau { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String VaiTro { get; set; }
        [ForeignKey("KhachHang")]
        public String MaKhachHang { get; set; }
        public virtual KhachHang KHang { get; set; }
        [Required]
        public String NgayTao { get; set; }
        [Required]
        public bool TrangThai { get; set; }
        
    }
}
