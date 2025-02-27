using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUAN_Homestay.Models
{
    public class LienHe
    {
        [Key]
        public String MaLienHe { get; set; }
        
        [Required]
        public String HoTen { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        [StringLength(10)]
        public String SoDienThoai { get; set; }
        [Required]
        public String NoiDung { get; set; }
        [Required]
        public String TrangThai { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }

        [ForeignKey("KhachHang")]
        public String MaKhachHang { get; set; }
        public virtual KhachHang KHang { get; set; }
    }
}
