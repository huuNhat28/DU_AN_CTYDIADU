using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DUAN_Homestay.Models
{
    public class DatPhong
    {
        [Key]
        public String MaDatPhong { get; set; }
        
        [Required]
        public DateTime NgayNhanPhong { get; set; }
        [Required]
        public DateTime NgayTraPhong { get; set; }       
        [Required]
        public String TrangThaiDat { get; set; }
        [Required]
        public long TongTien { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }

        [ForeignKey("KhachHang")]
        public String MaKhachHang { get; set; }
        public virtual KhachHang KHang { get; set; }
        [ForeignKey("Phong")]
        public String MaPhong { get; set; }
        public virtual Phong P { get; set; }

        [JsonIgnore]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

    }
}
