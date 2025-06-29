using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Reports;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Ledger;
using ZHOSPITAL.Models.ViewModel;

namespace ZHOSPITAL.Areas.Pharmacy.Controllers.Reports.Ledger
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhReceivePaymentsLedgerController : ControllerBase
    {
        #region Dependency Declearation

        private readonly IPhReport _vsReport;

        #endregion
        public PhReceivePaymentsLedgerController(IPhReport vsReport)
        {
            _vsReport = vsReport;
        }

        [HttpPost("/api/PhReceivePaymentsLedger/GetReceivePaymentsLedger")]
        public async Task<IActionResult> GetReceivePaymentsLedger(ReportResponseModel reportResponseModel)
        {
            try
            {
                IList<PhReceivePaymentsLedger> vSProducts = await _vsReport.GetReceivePaymentLedger(reportResponseModel);

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
