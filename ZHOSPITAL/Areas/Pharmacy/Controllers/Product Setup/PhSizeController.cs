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
    public class PhSizeController : ControllerBase
    {
        #region Dependency Declearation
       
        private readonly IPhSizeRepository _phSizeRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _phCustomCodeGenerate;

        #endregion

        #region Constructor       
        public PhSizeController(IPhSizeRepository phSizeRepository, IPhCustomCodeGenerate phCustomCodeGenerate)
        {
            _phSizeRepository = phSizeRepository;
            _phCustomCodeGenerate = phCustomCodeGenerate;
        }

        #endregion

        #region API Controller
       
        // GET: api/<CmnRegistrationController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<PhSize> sizes = _phSizeRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!sizes.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(sizes);
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
                PhSize size = _phSizeRepository.GetByCode(id);
                if (size != null)
                {
                    return Ok(size);
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
        public async Task<IActionResult> Post(PhSize size)
        {
            try
            {                
                bool isSaved = await _phSizeRepository.Add(size);
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
        public IActionResult Put(string id, [FromBody] PhSize size)
        {
            try
            {
                bool isUpdate = _phSizeRepository.Update(size);
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
                bool isDelete = _phSizeRepository.RemoveBySmallId(id);
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
