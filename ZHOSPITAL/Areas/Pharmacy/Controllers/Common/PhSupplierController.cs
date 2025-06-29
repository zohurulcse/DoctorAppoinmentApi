using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhSupplierController : ControllerBase
    {
        #region Dependency Declearation
       
        private readonly IPhSupplierRepository _phSupplierRepository;
        private readonly ISystemSecurity _systemSecurity;
        //private readonly IVSCustomCodeGenerate _vSCustomCodeGenerate;

        #endregion

        #region Constructor       
        public PhSupplierController(IPhSupplierRepository vSSupplierRepository)//, IVSCustomCodeGenerate vSCustomCodeGenerate
        {
            _phSupplierRepository = vSSupplierRepository;
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
                IList<PhSupplier> vSSuppliers = _phSupplierRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!vSSuppliers.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(vSSuppliers);
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
                PhSupplier vSSupplier = _phSupplierRepository.GetById(id);
                if (vSSupplier != null)
                {
                    return Ok(vSSupplier);
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
        public async Task<IActionResult> Post(PhSupplier vSSupplier)
        {
            try
            {
                //ImageHandler imageHandler = new ImageHandler();
                
                //vSSupplier.CustomCode =await _vSCustomCodeGenerate.CodeGenerator("SUP", "VSuppliers", "Code");
                bool isSaved =await _phSupplierRepository.Add(vSSupplier);
                if (isSaved)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CmnRegistrationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PhSupplier vSSupplier)
        {
            try
            {
                bool isUpdate = _phSupplierRepository.Update(vSSupplier);
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
                bool isDelete = _phSupplierRepository.RemoveByCode(id);
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
