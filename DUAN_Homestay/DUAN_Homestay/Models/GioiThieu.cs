using System.ComponentModel.DataAnnotations;

namespace DUAN_Homestay.Models
{
    public class GioiThieu
    {
        [Key]
        public String MaGioiThieu { get; set; }
        [Required]
        public String TieuDe { get; set; }
        [Required]
        public String NoiDung { get; set; }
        [Required]
        [StringLength(100)]
        public String HinhAnh { get; set; }
        [Required]
        public DateTime NgayCapNhat { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }


    }
}
