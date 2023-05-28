using Hotel_Solution.Repository;
using Microsoft.AspNetCore.Mvc;
using Hotel_Solution.Models;


namespace Hotel_Solution.Repository
{
    public class UserRepository:IURepository
    {
        private readonly MyDBContext _dbContext;
        public UserRepository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Hotel_book> GetAll()
        {
            return _dbContext.Hotel.ToList();
        }


       

        public void Add(Hotel_book hotel)
        {
            _dbContext.Hotel.Add(hotel);
            _dbContext.SaveChanges();

        }

        public Hotel_book GetById(int id)
        {
            return _dbContext.Hotel.Find(id);
        }

        
        public void UpdateHotels(Hotel_book hotel)
        {
            var dd = _dbContext.Hotel.Find(hotel.HotelId);
            if (dd != null)
            {
                
                _dbContext.Hotel.Update(dd);
                _dbContext.SaveChanges();

               
            }
            else
            {
                Console.WriteLine("ID is incorrect");
            }
            
        }
        public void DeleteHotel(int id)
        {
            try
            {
                var ph = _dbContext.Hotel.Find(id);
                if (ph != null)
                {


                    _dbContext.Hotel.Remove(ph);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to delete hotel",ex);
            }
        }
        public IEnumerable<Hotel_book> GetHotels(string location, decimal minPrice, decimal maxPrice)
        {
            var hotels_a = _dbContext.Hotel.ToList();

            return hotels_a.Where(h => h.location.Contains(location, StringComparison.OrdinalIgnoreCase) || (h.Price >= minPrice && h.Price <= maxPrice)).ToList();


           
            
           

        }



        public IEnumerable<Room_book> GetAll1()
        {
            return _dbContext.Room.ToList();
        }
        public void Add1(Room_book room)
        {
            _dbContext.Room.Add(room);
            _dbContext.SaveChanges();

        }
        public Room_book GetById2(int id,int id2)
        {
            return _dbContext.Room.FirstOrDefault(h => h.RoomNo == id && h.Hotel_Id == id2);
        }
        public void UpdateRooms(Room_book Rooms)
        {
            var dd = _dbContext.Room.Find(Rooms.RoomNo);
            if (dd != null)
            {

                Console.WriteLine("The id is incorrect ");
            }
            _dbContext.Room.Update(dd);
            _dbContext.SaveChanges();
        }
        public void DeleteRooms(int id,int roomidentity)
        {
            var ph = _dbContext.Room.FirstOrDefault(h => h.RoomNo == id && h.Hotel_Id == roomidentity);
            _dbContext.Room.Remove(ph);
            _dbContext.SaveChanges();
        }
        public int count(int Roomid)
        {
            int count = _dbContext.Room.Count(room => room.Hotel_Id == Roomid && room.Status == "Not Booked");
            return count;
        }

    }
}