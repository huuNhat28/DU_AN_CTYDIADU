using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DUAN_Homestay.Models
{
    public class Phong
    {
        [Key]
        public String MaPhong { get; set; }
        [Required]
        public int SoPhong { get; set; }
        [Required]
        public String LoaiPhong { get; set; }
        [Required]
        public long Gia { get; set; }
        [Required]
        public string TrangThai { get; set; }
        [Required]
        public string MoTa { get; set; }
        [Required]
        [StringLength(100)]
        public string HinhAnh { get; set; }
        [JsonIgnore]
        public virtual ICollection<DatPhong> DatPhongs { get; set; }

    }
}
