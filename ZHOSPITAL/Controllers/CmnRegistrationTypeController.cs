using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Database.Interface;
using ZHOSPITAL.Models.Setup;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnRegistrationTypeController : ControllerBase
    {
        private readonly IRegistrationTypeRepository _registrationTypeRepository;
        public CmnRegistrationTypeController(IRegistrationTypeRepository registrationTypeRepository)
        {
            _registrationTypeRepository  = registrationTypeRepository;
        }
        // GET: api/<CmnRegistrationTypeController>
        [HttpGet]
        public IActionResult Get()
        {
           List<RegistrationType> registrationType =  _registrationTypeRepository.GetAll();
            if (registrationType != null)
            {
                return Ok(registrationType);
            }
            else
            {
                return BadRequest();
            }
           
        }

        // GET api/<CmnRegistrationTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CmnRegistrationTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CmnRegistrationTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CmnRegistrationTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
