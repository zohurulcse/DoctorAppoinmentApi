using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Reports;
using ZHOSPITAL.Areas.Pharmacy.Data.Repository.Setup;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Purchase;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Reports.Purchase
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhPurchaseReportController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IPhReport _vsReport;

        #endregion
        public PhPurchaseReportController(IPhReport vsReport) 
        {
            _vsReport = vsReport;
        }

        [HttpPost("/api/PhPurchaseReport/GetPurchaseReport")]
        public async Task<IActionResult> GetPurchaseReport(ReportResponseModel reportResponseModel)
        {
            try
            {
                IList<PhPurchaseReportModel> vSProducts = await _vsReport.GetPurchaseReport(reportResponseModel);

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

        [HttpPost("/api/PhPurchaseReport/GetPurchaseReturn")]
        public async Task<IActionResult> GetPurchaseReturn(ReportResponseModel reportResponseModel)
        {
            try
            {
                IList<PhPurchaseReturnReportModel> vSProducts = await _vsReport.GetPurchaseReturnReport(reportResponseModel);

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
    }
}
