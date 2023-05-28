using System.ComponentModel.DataAnnotations;

namespace Hotel_Solution.Models
{
    public class Hotel_book
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string location { get; set; }
        public int Price { get; set; }

        public int Rating { get; set; }

        public ICollection<Room_book> Rooms { get; set; }


    }

}
