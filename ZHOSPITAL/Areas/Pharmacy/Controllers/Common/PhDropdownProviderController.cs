using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Commom;
using ZHOSPITAL.Areas.Pharmacy.Models.CRM;
using ZHOSPITAL.Areas.Pharmacy.Models.Inventory;
using ZHOSPITAL.Areas.Pharmacy.ViewModel;
using ZHOSPITAL.Database.Interface.Authority;
using ZHOSPITAL.Models.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhDropdownProviderController : ControllerBase
    {
        #region Dependency Declearation
        
        private readonly IPhDropdownProvider _phDropdownProvider;

        #endregion

        #region Constructor
      
        public PhDropdownProviderController(IPhDropdownProvider phDropdownProvider)
        {
            _phDropdownProvider = phDropdownProvider;
        }

        #endregion

        #region API Controller
        #endregion

        #region Custom API Controller
        
        [HttpGet("/api/PhDropdownProvider/getByDropdownData/{id}/{shopID}/{dropdownType}")]
        public async Task<IActionResult> GetByDropdownData(int id, int shopID, string dropdownType)
        {
            try
            {
                IList<PhResponseModel> vSProducts = await _phDropdownProvider.GetAllData(id,shopID, dropdownType);

                //Check List is Not Empty
                if (!vSProducts.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(vSProducts);
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
