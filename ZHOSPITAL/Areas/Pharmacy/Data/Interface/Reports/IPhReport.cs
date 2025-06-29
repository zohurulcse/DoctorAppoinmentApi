using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Purchase;
using ZHOSPITAL.Models.ViewModel;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Ledger;

namespace ZHOSPITAL.Areas.Pharmacy.Data.Interface.Reports
{
    public interface IPhReport
    {
        Task<List<PhPurchaseReportModel>> GetPurchaseReport(ReportResponseModel reportResponseModel);
        Task<List<PhPurchaseReturnReportModel>> GetPurchaseReturnReport(ReportResponseModel reportResponseModel);
        Task<List<PhSaleReportModel>> GetSaleReport(ReportResponseModel reportResponseModel);
        Task<List<PhSaleReturnReportModel>> GetSaleReturnReport(ReportResponseModel reportResponseModel);
        Task<List<PhStockReportModel>> GetStockReport(ReportResponseModel reportResponseModel);
        Task<List<PhReceivePaymentsLedger>> GetReceivePaymentLedger(ReportResponseModel reportResponseModel);
    }
}
