namespace DUAN_Homestay.Models
{
    public class Rooms
    {
        public int RoomID { get; set; }
        public required string RoomNumber { get; set; }
        public required int CategoryID { get; set; }
        public required decimal Price { get; set; }
        public required string Status { get; set; }
        public required string Description { get; set; }


    }
}
