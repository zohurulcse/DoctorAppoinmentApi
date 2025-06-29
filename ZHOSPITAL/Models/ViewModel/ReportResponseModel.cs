namespace ZHOSPITAL.Models.ViewModel
{
    public class ReportResponseModel
    {
        public string CustomCode { get; set; }
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; } = DateTime.Now;
        public int SupplierID { get; set; }
        public int CustomerID { get; set; }
        public int ShopID { get; set; }
    }
}
