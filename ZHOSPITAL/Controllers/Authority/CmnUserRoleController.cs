using Microsoft.AspNetCore.Mvc;
using ZAPI.Areas.VarietiesStore.Models.Authority;
using ZHOSPITAL.Areas.VarietiesStore;
using ZHOSPITAL.Database.Interface.Authority;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Controllers.Authority
{

    [Route("api/[controller]")]
    [ApiController]
    public class CmnUserRoleController : ControllerBase
    {
        #region Dependency Declearation

        private readonly ICmnUserRoleRepository _vsUserRoleRepository;
        private readonly ICmnUserRepository _vsUserRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly ICmnCustomCodeGenerate _vSCustomCodeGenerate;
        public readonly ZHOSPITALDbContext _db;

        #endregion

        #region Constructor

        public CmnUserRoleController(ICmnUserRepository vsUserRepository, ICmnUserRoleRepository vsUserRoleRepository, ICmnCustomCodeGenerate vSCustomCodeGenerate, ZHOSPITALDbContext db)
        {
            _vsUserRoleRepository = vsUserRoleRepository;
            _vsUserRepository = vsUserRepository;
            _vSCustomCodeGenerate = vSCustomCodeGenerate;
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
                IList<CmnUserRole> vSUserRole = _vsUserRoleRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!vSUserRole.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(vSUserRole);
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
                CmnUserRole vSUserRole = _vsUserRoleRepository.GetByCode(id);
                if (vSUserRole != null)
                {
                    return Ok(vSUserRole);
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
        public async Task<IActionResult> Post(CmnUserRole vSUserRole)
        {
            try
            {
                bool isSaved = await _vsUserRoleRepository.Add(vSUserRole);
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
        public IActionResult Put(string id, [FromBody] CmnUserRole vSUserRole)
        {
            try
            {
                bool isUpdate = _vsUserRoleRepository.Update(vSUserRole);
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
                bool isDelete = _vsUserRoleRepository.RemoveBySmallId(id);
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
