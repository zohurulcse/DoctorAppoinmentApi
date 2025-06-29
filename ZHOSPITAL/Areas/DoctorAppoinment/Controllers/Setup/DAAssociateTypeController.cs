using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.DoctorAppoinment.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class DAAssociateTypeController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IDAAssociateTypeRepository _daAssociateTypeRepository;
        private readonly ISystemSecurity _systemSecurity;
        //private readonly IVSCustomCodeGenerate _vSCustomCodeGenerate;

        #endregion

        #region Constructor       
        public DAAssociateTypeController(IDAAssociateTypeRepository daAssociateTypeRepository)//, IVSCustomCodeGenerate vSCustomCodeGenerate
        {
            _daAssociateTypeRepository = daAssociateTypeRepository;
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
                IList<DAAssociateType> associateType = _daAssociateTypeRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!associateType.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(associateType);
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
                DAAssociateType associateType = _daAssociateTypeRepository.GetById(id);
                if (associateType != null)
                {
                    return Ok(associateType);
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
        public async Task<IActionResult> Post(DAAssociateType associateType)
        {
            try
            {
                //ImageHandler imageHandler = new ImageHandler();

                //vSSupplier.CustomCode =await _vSCustomCodeGenerate.CodeGenerator("SUP", "VSuppliers", "Code");
                bool isSaved = await _daAssociateTypeRepository.Add(associateType);
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
        public IActionResult Put(string id, [FromBody] DAAssociateType associateType)
        {
            try
            {
                bool isUpdate = _daAssociateTypeRepository.Update(associateType);
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
                bool isDelete = _daAssociateTypeRepository.RemoveByCode(id);
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
