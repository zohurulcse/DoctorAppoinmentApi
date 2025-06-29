using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.Inventory;
using ZHOSPITAL.Areas.Pharmacy.Models.Purchase;
using ZHOSPITAL.Areas.Pharmacy.Models.Sales;
using ZHOSPITAL.Database.Interface.Authority;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Sale
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhSaleController : ControllerBase
    {
        #region Dependency Declearation
       
        private readonly IPhSalesHeadRepository _phSalesHeadRepository;
        private readonly IPhSalesDetailsRepository _phSalesDetailsRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _phCustomCodeGenerate;

        #endregion

        #region Constructor
        public PhSaleController(IPhSalesHeadRepository phSalesHeadRepository, IPhSalesDetailsRepository phSalesDetailsRepository, IPhCustomCodeGenerate phCustomCodeGenerate)
        {
            _phSalesHeadRepository = phSalesHeadRepository;
            _phSalesDetailsRepository = phSalesDetailsRepository;
            _phCustomCodeGenerate = phCustomCodeGenerate;
        }
        #endregion

        #region API Controller
       
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IList<PhSalesHead> salesHeads = _phSalesHeadRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!salesHeads.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(salesHeads);
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
                PhSalesHead salesHead = _phSalesHeadRepository.GetByCode(id);
                if (salesHead != null)
                {
                    return Ok(salesHead);
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
        public async Task<IActionResult> Post(PhSalesHead salesHead)
        {
            try
            {
                salesHead.CustomCode = await _phCustomCodeGenerate.CodeGenerator("SLS", "PhSalesHead", "CustomCode", salesHead.ShopID);
                bool isSaved =await _phSalesHeadRepository.Add(salesHead);
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
        public IActionResult Put(string id, [FromBody] PhSalesHead salesHead)
        {
            try
            {
                bool isUpdate = _phSalesHeadRepository.Update(salesHead);
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
                bool isDelete = _phSalesHeadRepository.RemoveByCode(id);
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
       
        [HttpGet("/api/PhSale/GetDataByShop/{shopID}/{approvedStatus}")]
        public IActionResult GetDataByShop(int shopID,string approvedStatus)
        {
            try
            {
                IList<PhSalesHead> salesHeads = _phSalesHeadRepository.GetDataByShop(shopID, approvedStatus).ToList();

                //Check List is Not Empty
                if (!salesHeads.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(salesHeads);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/PhSale/Approve/{id}")]
        public IActionResult Approve(long id) 
        {
            PhSalesHead salesHead = new PhSalesHead();
            salesHead = _phSalesHeadRepository.GetById(id);
            salesHead.ApproveStatus = "Approved";
            bool isApproved = _phSalesHeadRepository.Update(salesHead);
            if (isApproved) {
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
