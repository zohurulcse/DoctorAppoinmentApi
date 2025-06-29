namespace ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports.Purchase
{
    public class PhPurchaseReturnReportModel
    {
        public string SupplierName { get; set; }
        public DateTime PurchaseReturnDate { get; set; }
        public string PurchaseReturnCode { get; set; }
        public string PurchaseCode { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
    }
}
