using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.ViewModel
{
    public class PhProductOrderVM
    {
        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(20)]
        public string ProductCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public decimal? ControllerChargeAmount { get; set; }
        public decimal? SmartbazarChargeAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Photo { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? SalePrice { get; set; }

        [StringLength(20)]
        public string HeadCode { get; set; }

        [StringLength(20)]
        public string ShopCode { get; set; }

        [StringLength(50)]
        public string ShopName { get; set; }

        [StringLength(20)]
        public string CustomerCode { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }
        public string CustomerPhoto { get; set; }

        [StringLength(500)]
        public string CustomerAddress { get; set; }

        [StringLength(50)]
        public string CustomerFathers { get; set; }

        [StringLength(30)]
        public string CustomerMobile { get; set; }

        [StringLength(20)]
        public string OrderStatus { get; set; }

        [StringLength(50)]
        public string ParaMoholla { get; set; }

        [StringLength(50)]
        public string Village { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [StringLength(100)]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string PresendAddress { get; set; }

        [StringLength(500)]
        public string PermanantAddress { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [StringLength(20)]
        public string RegistrationType { get; set; }
    }
}
