namespace Hotel_Solution.Models
{
    public class Room_book
    {
        public int RoomNo { get; set; }


        public int Hotel_Id { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }

        public Hotel_book hotels_Boook { get; set; }
    }
}
