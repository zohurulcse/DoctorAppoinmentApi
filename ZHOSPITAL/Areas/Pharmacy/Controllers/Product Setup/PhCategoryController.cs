using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.ProductSetup;
using ZHOSPITAL.Areas.Pharmacy.Data.Repository.Setup;
using ZHOSPITAL.Areas.Pharmacy.Models.ProductSetup;
using ZHOSPITAL.Database.Interface.Authority;
using ZHOSPITAL.Models.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.VarietiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PhCategoryController : ControllerBase
    {
        #region Dependency Declearation
       
        private readonly IPhCategoryRepository _phCategoryRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _phCustomCodeGenerate;
        private readonly IPhDropdownProvider _vSDropdownProvider;

        #endregion

        #region Constructor
        public PhCategoryController(IPhCategoryRepository phCategoryRepository, IPhCustomCodeGenerate phCustomCodeGenerate, IPhDropdownProvider phDropdownProvider1)
        {
            _phCategoryRepository = phCategoryRepository;
            _phCustomCodeGenerate = phCustomCodeGenerate;
            _vSDropdownProvider = phDropdownProvider1;
        }

        #endregion

        #region API Controller
      
        // GET: api/<CmnRegistrationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IList<PhCategory> vSCategories = _phCategoryRepository.GetAll().ToList();               

                //Check List is Not Empty
                if (!vSCategories.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(vSCategories);
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
                PhCategory vSCategorie = _phCategoryRepository.GetByCode(id);
                if (vSCategorie != null)
                {
                    return Ok(vSCategorie);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<CmnRegistrationController>
        [HttpPost]
        public async Task<IActionResult> Post(PhCategory vSCategorie)
        {          
            try
            {              
                bool isSaved = await _phCategoryRepository.Add(vSCategorie);
                if (isSaved)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<CmnRegistrationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PhCategory vSCategorie)
        {
            try
            {
                bool isUpdate = _phCategoryRepository.Update(vSCategorie);
                if (isUpdate)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<CmnRegistrationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Int16 id)
        {
            try
            {
                bool isDelete = _phCategoryRepository.RemoveBySmallId(id);
                if (isDelete)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

        #region Custom API Controller
        #endregion
    }
}
