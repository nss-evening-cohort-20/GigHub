using Microsoft.AspNetCore.Mvc;
using GigHub.Repositories;
using GigHub.Models;



namespace GigHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        // GET: api/<EventController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventRepository.GetAllEvents());
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venueevent = _eventRepository.GetById(id);
            if (venueevent == null)
            {
                return NotFound();
            }
            return Ok(venueevent);
        }

        // POST api/<EventController>
        [HttpPost]
        public IActionResult Post(Event venueevent)
        {
            _eventRepository.Add(venueevent);
            return CreatedAtAction("Get", new { id = venueevent.Id }, venueevent);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Event venueevent)
        {
            if (id != venueevent.Id)
            {
                return BadRequest();
            }

            _eventRepository.Update(venueevent);
            return NoContent();
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _eventRepository.Delete(id);
            return NoContent();
        }
    }
}
