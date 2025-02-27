using System.ComponentModel.DataAnnotations;

namespace DUAN_Homestay.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
