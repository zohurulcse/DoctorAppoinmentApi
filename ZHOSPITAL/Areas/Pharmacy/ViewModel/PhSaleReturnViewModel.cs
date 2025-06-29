using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHOSPITAL.Areas.Pharmacy.ViewModel
{
    public class PhSaleReturnViewModel
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public decimal Totalquantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShopCode { get; set; }
        public string ReferenceCode { get; set; }
        public string Remarks { get; set; }
        public IList<PhSaleReturnDetailsViewModel> PhSaleReturnDetailsViewModels { get; set; }
    }

    public class PhSaleReturnDetailsViewModel
    {
        public string Productcode { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string ReferenceCode { get; set; }
    }
}
