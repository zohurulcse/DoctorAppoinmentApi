using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Reports;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Reports.Stock
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhStockReportController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IPhReport _vsReport;

        #endregion
        public PhStockReportController(IPhReport vsReport)
        {
            _vsReport = vsReport;
        }

        [HttpPost("/api/PhStockReport/GetStockReport")]
        public async Task<IActionResult> GetStockReport(ReportResponseModel reportResponseModel)
        {
            try
            {
                IList<PhStockReportModel> vSProducts = await _vsReport.GetStockReport(reportResponseModel);

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
