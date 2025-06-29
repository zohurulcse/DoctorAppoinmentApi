using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Database.Interface.Authority;
using ZHOSPITAL.Database.Interface.Common;
using ZHOSPITAL.Models.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZHOSPITAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmnDropdownProviderController : ControllerBase
    {
        #region Dependency Declearation
        
        private readonly ICmnDropdownProvider _cmnDropdownProvider;

        #endregion

        #region Constructor
      
        public CmnDropdownProviderController(ICmnDropdownProvider cmnDropdownProvider)
        {
            _cmnDropdownProvider = cmnDropdownProvider;
        }

        #endregion

        #region API Controller
        #endregion

        #region Custom API Controller
        
        [HttpGet("/api/CmnDropdownProvider/getByDropdownData/{id}/{shopID}/{dropdownType}")]
        public async Task<IActionResult> GetByDropdownData(int id, int shopID, string dropdownType)
        {
            try
            {
                IList<DropdownResponseModel> dropdownResponses = await _cmnDropdownProvider.GetAllData(id,shopID, dropdownType);

                //Check List is Not Empty
                if (!dropdownResponses.ToList().Any())
                {
                    //If List is Empty Then Send NotFound Status
                    return NotFound();
                }
                else
                {
                    return Ok(dropdownResponses);
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
