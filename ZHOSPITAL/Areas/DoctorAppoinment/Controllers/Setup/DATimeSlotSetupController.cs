using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.DoctorAppoinment.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class DATimeSlotSetupController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IDATimeSlotSetupRepository _daTimeSlotSetupRepository;
        private readonly ISystemSecurity _systemSecurity;
        //private readonly IVSCustomCodeGenerate _vSCustomCodeGenerate;

        #endregion

        #region Constructor       
        public DATimeSlotSetupController(IDATimeSlotSetupRepository daTimeSlotSetupRepository)//, IVSCustomCodeGenerate vSCustomCodeGenerate
        {
            _daTimeSlotSetupRepository = daTimeSlotSetupRepository;
            //_vSCustomCodeGenerate = vSCustomCodeGenerate;
        }

        #endregion

        #region API Controller        
        // GET: api/<CmnRegistrationController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<DATimeSlotSetup> timeSlotSetup = _daTimeSlotSetupRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!timeSlotSetup.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(timeSlotSetup);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CmnRegistrationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Int16 id)
        {
            try
            {
                DATimeSlotSetup timeSlotSetup = _daTimeSlotSetupRepository.GetById(id);
                if (timeSlotSetup != null)
                {
                    return Ok(timeSlotSetup);
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
        public async Task<IActionResult> Post(DATimeSlotSetup timeSlotSetup)
        {
            try
            {
                //ImageHandler imageHandler = new ImageHandler();

                //vSSupplier.CustomCode =await _vSCustomCodeGenerate.CodeGenerator("SUP", "VSuppliers", "Code");
                bool isSaved = await _daTimeSlotSetupRepository.Add(timeSlotSetup);
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
        public IActionResult Put(string id, [FromBody] DATimeSlotSetup timeSlotSetup)
        {
            try
            {
                bool isUpdate = _daTimeSlotSetupRepository.Update(timeSlotSetup);
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
                bool isDelete = _daTimeSlotSetupRepository.RemoveByCode(id);
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

        #region Custom API Controller
        #endregion
    }
}
