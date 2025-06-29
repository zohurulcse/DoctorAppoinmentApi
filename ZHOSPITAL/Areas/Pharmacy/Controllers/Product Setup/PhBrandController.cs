using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Interface.Authority;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhBrandController : ControllerBase
    {
        #region Dependency Declearation
        
        private readonly IPhBrandRepository _phBrandRepository ;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _vSCustomCodeGenerate;
        public readonly ZHOSPITALDbContext _db;

        #endregion

        #region Constructor
       
        public PhBrandController(IPhBrandRepository phBrandRepository, IPhCustomCodeGenerate phCustomCodeGenerate, ZHOSPITALDbContext db)
        {
            _phBrandRepository = phBrandRepository;
            _vSCustomCodeGenerate = phCustomCodeGenerate;
            _db = db;
        }

        #endregion

        #region API Controller      

        // GET: api/<CmnRegistrationController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<PhBrand> vSBrands = _phBrandRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!vSBrands.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(vSBrands);
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
                PhBrand vSBrand = _phBrandRepository.GetByCode(id);
                if (vSBrand != null)
                {
                    return Ok(vSBrand);
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
        public async Task<IActionResult> Post(PhBrand vSBrand)       
        {
            try
            {
                bool isSaved = await _phBrandRepository.Add(vSBrand);
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
        public IActionResult Put(string id, [FromBody] PhBrand vSBrand)
        {
            try
            {
                bool isUpdate = _phBrandRepository.Update(vSBrand);
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
        public IActionResult Delete(Int16 id)
        {
            try
            {
                bool isDelete = _phBrandRepository.RemoveBySmallId(id);
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
