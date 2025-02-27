using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DUAN_Homestay.Models
{
    public class Rooms
    {
        [Key]
        public int RoomID { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Users> Category { get; set; }


    }
}
