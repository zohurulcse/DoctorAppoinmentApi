namespace ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Purchase
{
    public class PhPurchaseReportModel
    {
        public string SupplierName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string CustomCode { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? NetAmount { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
