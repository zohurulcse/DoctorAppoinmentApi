using Dapper;
using System.Data;
using ZHOSPITAL.Utility;
using ZHOSPITAL.Database.Utility;
using ZHOSPITAL.Models.ViewModel;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Purchase;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports;
using ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Ledger;
using ZHOSPITAL.Areas.Pharmacy.Data.Interface.Reports;

namespace ZHOSPITAL.Areas.Pharmacy
{
    public class PhReportRepository : IPhReport
    {
        private readonly IDBAccess _dbAccess;
        public PhReportRepository(IDBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }
        public async Task<List<PhPurchaseReportModel>> GetPurchaseReport(ReportResponseModel reportResponseModel)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhPurchaseReportModel>)await _con.QueryAsync<PhPurchaseReportModel>(
                sql: Convert.ToString(StoreProcedure.Name.RPT_SPVSPurchaseReport),
                    param: new
                    {
                        SupplierID = reportResponseModel.SupplierID,
                        FromDate = reportResponseModel.FromDate,
                        ToDate = reportResponseModel.ToDate,
                        CustomCode = reportResponseModel.CustomCode,
                        ShopID= reportResponseModel.ShopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhPurchaseReportModel>();
        }

        public async Task<List<PhPurchaseReturnReportModel>> GetPurchaseReturnReport(ReportResponseModel reportResponseModel)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhPurchaseReturnReportModel>)await _con.QueryAsync<PhPurchaseReturnReportModel>(
                sql: Convert.ToString(StoreProcedure.Name.RPT_SPVSPurchaseReturnReport),
                    param: new
                    {
                        SupplierID = reportResponseModel.SupplierID,
                        FromDate = reportResponseModel.FromDate,
                        ToDate = reportResponseModel.ToDate,
                        CustomCode = reportResponseModel.CustomCode,
                        ShopID = reportResponseModel.ShopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhPurchaseReturnReportModel>();
        }       

        public async Task<List<PhSaleReportModel>> GetSaleReport(ReportResponseModel reportResponseModel)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhSaleReportModel>)await _con.QueryAsync<PhSaleReportModel>(
                sql: Convert.ToString(StoreProcedure.Name.RPT_SPVSSaleReport),
                    param: new
                    {
                        CustomerID = reportResponseModel.CustomerID,
                        FromDate = reportResponseModel.FromDate,
                        ToDate = reportResponseModel.ToDate,
                        CustomCode = reportResponseModel.CustomCode,
                        ShopID = reportResponseModel.ShopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhSaleReportModel>();
        }

        public async Task<List<PhSaleReturnReportModel>> GetSaleReturnReport(ReportResponseModel reportResponseModel)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhSaleReturnReportModel>)await _con.QueryAsync<PhSaleReturnReportModel>(
                sql: Convert.ToString(StoreProcedure.Name.RPT_SPVSSaleReturnReport),
                    param: new
                    {
                        CustomerID = reportResponseModel.CustomerID,
                        FromDate = reportResponseModel.FromDate,
                        ToDate = reportResponseModel.ToDate,
                        CustomCode = reportResponseModel.CustomCode,
                        ShopID = reportResponseModel.ShopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhSaleReturnReportModel>();
        }

        public async Task<List<PhStockReportModel>> GetStockReport(ReportResponseModel reportResponseModel)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhStockReportModel>)await _con.QueryAsync<PhStockReportModel>(
                sql: Convert.ToString(StoreProcedure.Name.RPT_SPVSStockReport),
                    param: new
                    {
                        SupplierID = reportResponseModel.SupplierID,
                        FromDate = reportResponseModel.FromDate,
                        ToDate = reportResponseModel.ToDate,                      
                        ShopID = reportResponseModel.ShopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhStockReportModel>();
        }

        public async Task<List<PhReceivePaymentsLedger>> GetReceivePaymentLedger(ReportResponseModel reportResponseModel)
        {
            using var _con = _dbAccess.GetConnection();
            var objList = (List<PhReceivePaymentsLedger>)await _con.QueryAsync<PhReceivePaymentsLedger>(
                sql: Convert.ToString(StoreProcedure.Name.RPT_VSSupplierCustomerLedger),
                    param: new
                    {
                        LedgerCode = reportResponseModel.CustomCode,
                        FromDate = reportResponseModel.FromDate,
                        ToDate = reportResponseModel.ToDate,
                        ShopID = reportResponseModel.ShopID
                    },
                commandType: CommandType.StoredProcedure);
            return objList ?? new List<PhReceivePaymentsLedger>();
        }
    }
}
