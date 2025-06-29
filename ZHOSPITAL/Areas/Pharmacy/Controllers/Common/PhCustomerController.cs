using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Areas.Pharmacy.Models.Inventory;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhCustomerController : ControllerBase
    {
        #region Dependency Declearation
       
        private readonly IPhCustomerRepository _phCustomerRepository;
        private readonly ISystemSecurity _systemSecurity;
        //private readonly IPhCustomCodeGenerate _vSCustomCodeGenerate;

        #endregion

        #region Constructor       
        public PhCustomerController(IPhCustomerRepository phCustomerRepository)//, IVSCustomCodeGenerate vSCustomCodeGenerate
        {
            _phCustomerRepository = phCustomerRepository;
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
                IList<PhCustomer> vSCustomers = _phCustomerRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!vSCustomers.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(vSCustomers);
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
                PhCustomer vSCustomer = _phCustomerRepository.GetByCode(id);
                if (vSCustomer != null)
                {
                    return Ok(vSCustomer);
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
        public async Task<IActionResult> Post(PhCustomer vSCustomer)
        {
            try
            {              
                bool isSaved = await _phCustomerRepository.Add(vSCustomer);
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
        public IActionResult Put(string id, [FromBody] PhCustomer vSCustomer)
        {
            try
            {
                bool isUpdate = _phCustomerRepository.Update(vSCustomer);
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
                bool isDelete = _phCustomerRepository.RemoveByCode(id);
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
