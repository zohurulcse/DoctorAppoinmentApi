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
    public class PhSaleReturnController : ControllerBase
    {

        #region Dependency Declearation

        private readonly IPhSaleReturnHeadRepository _phSaleReturnHeadRepository;
        private readonly IPhSaleReturnDetailsRepository _phSaleReturnDetailsRepository;
        private readonly ISystemSecurity _systemSecurity;
        private readonly IPhCustomCodeGenerate _phCustomCodeGenerate;

        #endregion

        #region Constructor
        public PhSaleReturnController(IPhSaleReturnHeadRepository phSaleReturnHeadRepository, IPhSaleReturnDetailsRepository phSaleReturnDetailsRepository, IPhCustomCodeGenerate phCustomCodeGenerate)
        {
            _phSaleReturnHeadRepository = phSaleReturnHeadRepository;
            _phSaleReturnDetailsRepository = phSaleReturnDetailsRepository;
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
                IList<PhSaleReturnHead> saleReturnHeads = _phSaleReturnHeadRepository.GetAll().ToList();

                //Check List is Not Empty
                if (!saleReturnHeads.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(saleReturnHeads);
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
                PhSaleReturnHead saleReturnHead = _phSaleReturnHeadRepository.GetByCode(id);
                if (saleReturnHead != null)
                {
                    return Ok(saleReturnHead);
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
        public async Task<IActionResult> Post(PhSaleReturnHead saleReturnHead)
        {
            try
            {
                saleReturnHead.CustomCode =await _phCustomCodeGenerate.CodeGenerator("SRH", "PhSaleReturnHead", "CustomCode", saleReturnHead.ShopID);
                bool isSaved = await _phSaleReturnHeadRepository.Add(saleReturnHead);
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
        public IActionResult Put(string id, [FromBody] PhSaleReturnHead saleReturnHead)
        {
            try
            {
                bool isUpdate = _phSaleReturnHeadRepository.Update(saleReturnHead);
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
                bool isDelete = _phSaleReturnHeadRepository.RemoveByCode(id);
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
       
        [HttpGet("/api/PhSaleReturn/GetDataByShop/{shopID}/{approvedStatus}")]
        public IActionResult GetDataByShop(int shopID, string approvedStatus)
        {
            try
            {
                IList<PhSaleReturnHead> saleReturnHead = _phSaleReturnHeadRepository.GetDataByShop(shopID,approvedStatus).ToList();

                //Check List is Not Empty
                if (!saleReturnHead.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(saleReturnHead);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/PhSaleReturn/Approve/{id}")]
        public IActionResult Approve(long id)
        {
            PhSaleReturnHead saleReturnHead = new PhSaleReturnHead();
            saleReturnHead = _phSaleReturnHeadRepository.GetById(id);
            saleReturnHead.ApproveStatus = "Approved";
            bool isApproved = _phSaleReturnHeadRepository.Update(saleReturnHead);
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
