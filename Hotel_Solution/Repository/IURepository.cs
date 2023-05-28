using Hotel_Solution.Models;
namespace Hotel_Solution.Repository
{
    public interface IURepository
    {
        IEnumerable<Hotel_book> GetAll();
        void Add(Hotel_book Hotel);

        Hotel_book GetById(int id);
        void UpdateHotels(Hotel_book hotel);

        IEnumerable<Hotel_book> GetHotels(string location, decimal minPrice, decimal maxPrice);


        void DeleteHotel(int id);
        //void SaveChanges();

        public IEnumerable<Room_book> GetAll1();
        public void Add1(Room_book Room);
        public Room_book GetById2(int id,int id2);
        public void UpdateRooms(Room_book Rooms);
        void DeleteRooms(int id,int roomidentity);
        public int count(int Roomid);

    }
}