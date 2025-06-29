using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.DoctorAppoinment.Controllers.Doctor
{
    [Route("api/[controller]")]
    [ApiController]
    public class DADoctorAppoinmentController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IDADoctorAppoinmentRepository _daDoctorAppoinmentRepository;
        private readonly ISystemSecurity _systemSecurity;
        //private readonly IVSCustomCodeGenerate _vSCustomCodeGenerate;

        #endregion

        #region Constructor       
        public DADoctorAppoinmentController(IDADoctorAppoinmentRepository daDoctorAppoinmentRepository)//, IVSCustomCodeGenerate vSCustomCodeGenerate
        {
            _daDoctorAppoinmentRepository = daDoctorAppoinmentRepository;
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
                IList<DADoctorAppoinment> doctorAppoinment = _daDoctorAppoinmentRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!doctorAppoinment.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(doctorAppoinment);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CmnRegistrationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                DADoctorAppoinment doctorAppoinment = _daDoctorAppoinmentRepository.GetById(id);
                if (doctorAppoinment != null)
                {
                    return Ok(doctorAppoinment);
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
        public async Task<IActionResult> Post(DADoctorAppoinment doctorAppoinment)
        {
            try
            {
                //ImageHandler imageHandler = new ImageHandler();

                //vSSupplier.CustomCode =await _vSCustomCodeGenerate.CodeGenerator("SUP", "VSuppliers", "Code");
                bool isSaved = await _daDoctorAppoinmentRepository.Add(doctorAppoinment);
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
        public IActionResult Put(string id, [FromBody] DADoctorAppoinment doctorAppoinment)
        {
            try
            {
                bool isUpdate = _daDoctorAppoinmentRepository.Update(doctorAppoinment);
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
                bool isDelete = _daDoctorAppoinmentRepository.RemoveByCode(id);
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
