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
    public class PhPurchaseController : ControllerBase
    {
        #region Dependency Declearation
       
        private readonly IPhPurchaseHeadRepository _phPurchaseHeadRepository;
        private readonly IPhPurchaseDetailsRepository _phPurchaseDetailsRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _phCustomCodeGenerate;

        #endregion

        #region Constructor
        public PhPurchaseController(
            IPhPurchaseHeadRepository phPurchaseHeadRepository, 
            IPhPurchaseDetailsRepository phPurchaseDetailsRepository, 
            IPhCustomCodeGenerate phCustomCodeGenerate
            )
        {
            _phPurchaseHeadRepository = phPurchaseHeadRepository;
            _phPurchaseDetailsRepository = phPurchaseDetailsRepository;
            _phCustomCodeGenerate = phCustomCodeGenerate;
        }

        #endregion

        #region API Controller
             
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<PhPurchaseHead> purchaseHeads = _phPurchaseHeadRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!purchaseHeads.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(purchaseHeads);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                PhPurchaseHead purchaseHead = _phPurchaseHeadRepository.GetByCode(id);
                if (purchaseHead != null)
                {
                    return Ok(purchaseHead);
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
      
        [HttpPost]
        public async Task<IActionResult> Post(PhPurchaseHead purchaseHead)
        {
            try
            {

                purchaseHead.CustomCode =await _phCustomCodeGenerate.CodeGenerator("PUR", "PhPurchaseHead", "CustomCode", purchaseHead.ShopID);

                bool isSaved = await _phPurchaseHeadRepository.Add(purchaseHead);
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
      
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PhPurchaseHead purchaseHead)
        {
            try
            {
                bool isUpdate = _phPurchaseHeadRepository.Update(purchaseHead);
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
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                bool isDelete = _phPurchaseHeadRepository.RemoveByCode(id);
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
       
        [HttpGet("/api/PhPurchase/GetDataByShop/{shopID}/{approvedStatus}")]
        public IActionResult GetDataByShop(int shopID,string approvedStatus)
        {
            try
            {
                IList<PhPurchaseHead> purchaseHead = _phPurchaseHeadRepository.GetDataByShop(shopID, approvedStatus).ToList();

                //Check List is Not Empty
                if (!purchaseHead.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(purchaseHead);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/PhPurchase/Approve/{id}")]
        public IActionResult Approve(long id)
        {
            PhPurchaseHead purchaseHead = new PhPurchaseHead();
            purchaseHead = _phPurchaseHeadRepository.GetById(id);
            purchaseHead.ApproveStatus = "Approved";
            bool isApproved = _phPurchaseHeadRepository.Update(purchaseHead);
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
