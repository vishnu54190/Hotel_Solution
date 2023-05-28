namespace Hotel_Solution.Controllers
{
    using Hotel_Solution.Models;
    using Hotel_Solution.Repository;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Hotel_Solution.Repository;
    using NuGet.Protocol.Core.Types;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;

    
    [Route("api/[controller]")]
    [ApiController]
    public class Room_bookController : ControllerBase
    {
        private readonly IURepository _repository;

        public Room_bookController(IURepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Room_book>> GetAll()
        {
            return _repository.GetAll1();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room_book>> GetById(int id,int id2)
        {
            var room = _repository.GetById2(id,id2);
            if (room == null)
            {
                return NotFound();
            }
            return room;
        }
        [HttpGet("Count")]
        public int Countnum(int Roomid)
        {
            return _repository.count(Roomid);
            
        }

        [HttpPost]
        public async Task<ActionResult<Room_book>> Add([FromBody] Room_book room)
        {
            _repository.Add1(room);
            return Ok(room);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Room_book>> UpdateRooms(Room_book Rooms)
        {
            _repository.UpdateRooms(Rooms);
            return Ok(Rooms);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room_book>> DeleteRooms(int id,int roomidentity)
        {
            {
                _repository.DeleteRooms(id,roomidentity);

                return Ok();
            }
        }
    }
}
