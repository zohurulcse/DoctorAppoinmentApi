using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.Common;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.DoctorAppoinment.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class DADepartmentController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IDADepartmentRepository _daDepartmentRepository;
        private readonly ISystemSecurity _systemSecurity;
        //private readonly IVSCustomCodeGenerate _vSCustomCodeGenerate;

        #endregion

        #region Constructor       
        public DADepartmentController(IDADepartmentRepository daDepartmentRepository)//, IVSCustomCodeGenerate vSCustomCodeGenerate
        {
            _daDepartmentRepository = daDepartmentRepository;
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
                IList<DADepartment> department = _daDepartmentRepository.GetAll().Where(x=> x.IsActive == true).ToList();

                //Check List is Not Empty
                if (!department.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(department);
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
                DADepartment department = _daDepartmentRepository.GetById(id);
                if (department != null)
                {
                    return Ok(department);
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
        public async Task<IActionResult> Post(DADepartment department)
        {
            try
            {
                //ImageHandler imageHandler = new ImageHandler();

                //vSSupplier.CustomCode =await _vSCustomCodeGenerate.CodeGenerator("SUP", "VSuppliers", "Code");
                bool isSaved = await _daDepartmentRepository.Add(department);
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
        public IActionResult Put(string id, [FromBody] DADepartment department)
        {
            try
            {
                bool isUpdate = _daDepartmentRepository.Update(department);
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
                bool isDelete = _daDepartmentRepository.RemoveBySmallId(id);
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
