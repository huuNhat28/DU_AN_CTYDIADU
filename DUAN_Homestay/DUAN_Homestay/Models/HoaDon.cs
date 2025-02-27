using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DUAN_Homestay.Models
{
    public class HoaDon
    {
        [Key]
        public String MaHoaDon { get; set; }
        [Required]
        public long TongTien { get; set; }
        [Required]
        public String TrangThaiThanhToan { get; set; }
        [Required]
        public String PhuongThucThanhToan { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }

        [ForeignKey("DatPhong")]
        public String MaDatPhong { get; set; }
        public virtual DatPhong DPhong { get; set; }

    }
}
