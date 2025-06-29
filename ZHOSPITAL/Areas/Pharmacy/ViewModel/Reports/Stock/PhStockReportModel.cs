namespace ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports
{
    public class PhStockReportModel
    {
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string StyleName { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public string UnitName { get; set; }      
        public decimal? SalePrice { get; set; }
        public int CurrentStock { get; set; }
    }
}
