using GigHub.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GigHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;

        public VenueController(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        // GET: api/<VenueController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_venueRepository.GetAllVenues());
        }

        // GET api/<VenueController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var venue = _venueRepository.GetById(id);
            if (venue == null)
            {
                return NotFound();
            }
            return Ok(venue);
        }

        // GET api/<VenueController>/5
        [HttpGet("{zipcode}")]
        public IActionResult GetByZipcode(int zipcode)
        {
            var venue = _venueRepository.GetByZipcode(zipcode);
            if (venue == null)
            {
                return NotFound();
            }
            return Ok(venue);
        }

        // POST api/<VenueController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VenueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VenueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
