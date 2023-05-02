using GigHub.Models;
using GigHub.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GigHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository=serviceRepository;
        }


        // GET: api/<ServicesController>
        [HttpGet]
        public IActionResult Get()
        {


            var services = _serviceRepository.GetAllServices();

            return Ok(services); 
        }


        // GET api/<ServicesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // 1. get service by Id using the repo
            // 2. check if we successfully retrieved anything
            // 3. handle "found" and "not found"

            var service = _serviceRepository.GetServiceById(id);
            if (service == null)
            {
                // if not found = this is what we add what to do
                return NotFound($"Could not found service with id {id}.");
            }

            return Ok(service);
        }

        // POST api/<ServicesController>
        [HttpPost]
        public IActionResult AddNewService(Service service)
        {
            _serviceRepository.AddNewService(service);
            return CreatedAtAction("Get", new { id = service.Id }, service);
        }

        // PUT api/<ServicesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
            return NoContent();
               
        }
    }
}
