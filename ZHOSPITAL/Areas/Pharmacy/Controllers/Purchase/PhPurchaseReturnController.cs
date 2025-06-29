using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Purchase
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhPurchaseReturnController : ControllerBase
    {

        #region Dependency Declearation
      
        private readonly IPhPurchaseReturnHeadRepository _phPurchaseReturnHeadRepository;
        private readonly IPhPurchaseReturnDetailsRepository _phPurchaseReturnDetailsRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _phCustomCodeGenerate;

        #endregion

        #region Constructor
        public PhPurchaseReturnController(
            IPhPurchaseReturnHeadRepository phPurchaseReturnHeadRepository,
            IPhPurchaseReturnDetailsRepository phPurchaseReturnDetailsRepository,
            IPhCustomCodeGenerate phCustomCodeGenerate
        )
        {
            _phPurchaseReturnHeadRepository = phPurchaseReturnHeadRepository;
            _phPurchaseReturnDetailsRepository = phPurchaseReturnDetailsRepository;
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
                IList<PhPurchaseReturnHead> purchaseReturnHeads = _phPurchaseReturnHeadRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!purchaseReturnHeads.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(purchaseReturnHeads);
                }

            }
            catch
            {
                //Send Bad Request Status
                return BadRequest();
            }
        }

        // GET api/<CmnRegistrationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                PhPurchaseReturnHead purchaseReturnHead = _phPurchaseReturnHeadRepository.GetByCode(id);
                if (purchaseReturnHead != null)
                {
                    return Ok(purchaseReturnHead);
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
        public async Task<IActionResult> Post(PhPurchaseReturnHead purchaseReturnHead)
        {
            try
            {
                purchaseReturnHead.CustomCode = await _phCustomCodeGenerate.CodeGenerator("PRH", "VSPurchaseReturnHead", "CustomCode", purchaseReturnHead.ShopID);
                bool isSaved = await _phPurchaseReturnHeadRepository.Add(purchaseReturnHead);
                if (isSaved)
                {
                    return Ok();
                }
                else
                {
                    return NotFound("Save Not Successfully!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CmnRegistrationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PhPurchaseReturnHead purchaseReturnHead)
        {
            try
            {
                bool isUpdate = _phPurchaseReturnHeadRepository.Update(purchaseReturnHead);
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
                bool isDelete = _phPurchaseReturnHeadRepository.RemoveByCode(id);
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

        [HttpGet("/api/PhPurchaseReturn/GetDataByShop/{shopID}/{approvedStatus}")]
        public IActionResult GetDataByShop(int shopID,string approvedStatus)
        {
            try
            {
                IList<PhPurchaseReturnHead> purchaseReturnHeads = _phPurchaseReturnHeadRepository.GetDataByShop(shopID, approvedStatus).ToList();

                //Check List is Not Empty
                if (!purchaseReturnHeads.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(purchaseReturnHeads);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/PhPurchaseReturn/Approve/{id}")]
        public IActionResult Approve(int id)
        {
            PhPurchaseReturnHead purchaseReturnHead = new PhPurchaseReturnHead();
            purchaseReturnHead = _phPurchaseReturnHeadRepository.GetById(id);
            purchaseReturnHead.ApproveStatus = "Approved";
            bool isApproved = _phPurchaseReturnHeadRepository.Update(purchaseReturnHead);
            if (isApproved)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        #endregion
    }
}
