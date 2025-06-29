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
    public class PhColorController : ControllerBase
    {
        #region Dependency Declearation
        
        private readonly IPhColorRepository _phColorRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _vSCustomCodeGenerate;

        #endregion

        #region Constructor
        public PhColorController(IPhColorRepository phColorRepository, IPhCustomCodeGenerate phCustomCodeGenerate)
        {
            _phColorRepository = phColorRepository;
            _vSCustomCodeGenerate = phCustomCodeGenerate;
        }
        #endregion

        #region API Controller
       
        // GET: api/<CmnRegistrationController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<PhColor> phColors = _phColorRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!phColors.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(phColors);
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
                PhColor phColor = _phColorRepository.GetByCode(id);
                if (phColor != null)
                {
                    return Ok(phColor);
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
        public async Task<IActionResult> Post(PhColor phColor)
        {
            try
            {               
                bool isSaved = await _phColorRepository.Add(phColor);
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
        public IActionResult Put(string id, [FromBody] PhColor phColor)
        {
            try
            {
                bool isUpdate = _phColorRepository.Update(phColor);
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
                bool isDelete = _phColorRepository.RemoveBySmallId(id);
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
