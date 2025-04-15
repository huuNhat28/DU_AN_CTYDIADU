using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DUAN_Homestay.Models
{
    public class KhachHang
    {
        [Key]
        public String MaKhachHang { get; set; }
        [Required]
        public String HoTen { get; set; }
        [Required]
        [StringLength(10)]
        public String SoDienThoai { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        [StringLength(12)]
        public String SoCCCD { get; set; }
        public String DiaChi { get; set; }
        [StringLength(100)]
        public String HinhAnh { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }

        [JsonIgnore]
        public virtual ICollection<DatPhong> DatPhongs { get; set; }
        [JsonIgnore]
        public virtual ICollection<LienHe> LienHes { get; set; }
        [JsonIgnore]
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }

    }
}
