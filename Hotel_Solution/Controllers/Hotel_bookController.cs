namespace Hotel_Solution.Controllers
{
    using Hotel_Solution.Models;
    using Hotel_Solution.Repository;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Hotel_Solution.Repository;
    using Microsoft.AspNetCore.Authorization;


    [Route("api/[controller]")]
    [ApiController]
    public class Hotel_bookController : ControllerBase
    {
        private readonly IURepository _repository;

        public Hotel_bookController(IURepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Hotel_book>> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel_book>> GetById(int id)
        {
            var hotel = _repository.GetById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return hotel;
        }

        [HttpPost]
        public async Task<ActionResult<Hotel_book>> Add([FromBody] Hotel_book hotel)
        {
            _repository.Add(hotel);
            return Ok(hotel);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Hotel_book>> UpdateHotels(Hotel_book hotel)
        {
            _repository.UpdateHotels(hotel);
            return Ok(hotel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel_book>> DeleteHotel(int id)
        {
            {
                _repository.DeleteHotel(id);

                return Ok();
            }
        }
        [HttpGet("Hotels")]
        public async Task<IEnumerable<Hotel_book>> GetHotels2(string location, decimal minPrice, decimal maxPrice)
        {
            
            return _repository.GetHotels(location, minPrice, maxPrice);
        }

    }
}
