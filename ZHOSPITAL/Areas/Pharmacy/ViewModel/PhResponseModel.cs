namespace ZHOSPITAL.Areas.Pharmacy.ViewModel
{
    public class PhResponseModel
    {
        public int id { get; set; }
        public string customCode { get; set; }
        public string MobileNumber { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int CustomerID { get; set; }
        public int ShopID { get; set; }
        public string name { get; set; }
        public int Stock { get; set; }
        public decimal? Price { get; set; }
    }
}
