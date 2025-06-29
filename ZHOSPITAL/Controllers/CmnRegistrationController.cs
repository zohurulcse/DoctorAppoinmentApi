using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ZHOSPITAL.Database.Interface;
using ZHOSPITAL.Database.Interface.Authority;
using ZHOSPITAL.Models.Setup;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnRegistrationController : ControllerBase
    {
        #region declearation
        private readonly IRegistrationRepository _registrationRepository;
        private readonly ICmnCustomCodeGenerate _vSCustomCodeGenerate;
        #endregion

        #region constructor
        public CmnRegistrationController(IRegistrationRepository registrationRepository, ICmnCustomCodeGenerate vSCustomCodeGenerate)
        {
            _registrationRepository = registrationRepository;
            _vSCustomCodeGenerate = vSCustomCodeGenerate;
        }
        #endregion

        #region api action
       
        // GET: api/<CmnRegistrationController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<Registration> registrations = _registrationRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!registrations.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(registrations);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CmnRegistrationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                Registration registrations = _registrationRepository.GetByCode(id);
                if (registrations != null)
                {
                    return Ok(registrations);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CmnRegistrationController>
        [HttpPost]
        public async Task<IActionResult> Post(Registration registration)
        {
            try
            {                
                bool isSaved = await _registrationRepository.Add(registration);
                if (isSaved)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CmnRegistrationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Registration registration)
        {
            try
            {
                bool isUpdate = _registrationRepository.Update(registration);
                if (isUpdate)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CmnRegistrationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                bool isDelete = _registrationRepository.RemoveByCode(id);
                if (isDelete)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
