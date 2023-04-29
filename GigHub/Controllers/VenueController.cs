using GigHub.Repositories;
using GigHub.Models;
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
        [HttpGet("GetVenueById")]
        public IActionResult GetById(int id)
        {
            var venue = _venueRepository.GetById(id);
            if (venue == null)
            {
                return NotFound();
            }
            return Ok(venue);
        }

        // GET api/<VenueController>/37214
        [HttpGet("GetVenueByZipcode")]
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
        public IActionResult Post(Venue venue)
        {
            _venueRepository.Add(venue);
            return CreatedAtAction("get", new { id = venue.Id }, venue);
        }

        // PUT api/<VenueController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Venue venue)
        {
            if (id != venue.Id)
            {
                return BadRequest();
            }

            _venueRepository.Update(venue);
            return NoContent();
        }

        // DELETE api/<VenueController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _venueRepository.Delete(id);
            return NoContent();
        }
    }
}
