using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Reports;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Purchase;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Reports.Sale
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhSaleReportController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IPhReport _vsReport;

        #endregion
        public PhSaleReportController(IPhReport vsReport)
        {
            _vsReport = vsReport;
        }

        [HttpPost("/api/PhSaleReport/GetSaleReport")]
        public async Task<IActionResult> GetSaleReport(ReportResponseModel reportResponseModel)
        {
            try
            {
                IList<PhSaleReportModel> vSProducts = await _vsReport.GetSaleReport(reportResponseModel);

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

        [HttpPost("/api/PhSaleReport/GetSaleReturn")]
        public async Task<IActionResult> GetSaleReturn(ReportResponseModel reportResponseModel)
        {
            try
            {
                IList<PhSaleReturnReportModel> vSProducts = await _vsReport.GetSaleReturnReport(reportResponseModel);

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
