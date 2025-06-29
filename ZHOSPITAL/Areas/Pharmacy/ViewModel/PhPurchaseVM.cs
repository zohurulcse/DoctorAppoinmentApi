using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.ViewModel
{
    public class PhPurchaseVM
    {
        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(20)]
        public string ProductCode { get; set; }
        public string Photo { get; set; }
        public DateTime? Date { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? CostPrice { get; set; }

        [StringLength(20)]
        public string HeadCode { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(20)]
        public string ShopCode { get; set; }

        [StringLength(20)]
        public string ReferenceCode { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? TotalQuantity { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
