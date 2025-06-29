namespace ZHOSPITAL.Areas.Pharmacy.ViewModel.Reports
{
    public class PhSaleReturnReportModel
    {
        public string CustomerName { get; set; }
        public DateTime SaleReturnDate { get; set; }
        public string CustomCode { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
    }
}
