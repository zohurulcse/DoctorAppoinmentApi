using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHOSPITAL.Areas.Pharmacy.ViewModel
{
    public class PhSaleViewModel
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public decimal Totalquantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public string ShopCode { get; set; }
        public IList<PhSaleDetailsViewModel> PhSaleDetailsViewModels { get; set; }
    }

    public class PhSaleDetailsViewModel
    {
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }
}
