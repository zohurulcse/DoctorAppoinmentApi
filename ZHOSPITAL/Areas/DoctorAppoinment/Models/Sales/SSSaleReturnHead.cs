using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Areas.VarietiesStore.Models.CRM;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.VarietiesStore.Models.Sales
{
    [Table("SSSaleReturnHead")]
    public class SSSaleReturnHead
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime Date { get; set; }


        [Display(Name = "Customer Name")]
        [Required]
        public string CustomerCode { get; set; }
        [ForeignKey("CustomerCode")]
        public virtual VSCustomer Customer { get; set; }

        [Required]
        [Display(Name = "Total Quantity")]
        public decimal TotalQuantity { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Discount(%)")]
        [DefaultValue(0)]
        public decimal TotalDiscountPercent { get; set; }

        [Display(Name = "Discount(TK)")]
        [DefaultValue(0)]
        public decimal TotalDiscount { get; set; }

        [Display(Name = "Grand Total")]
        [DefaultValue(0)]
        public double GrandTotal { get; set; }

        [Display(Name = "Vat(%)")]
        [DefaultValue(0)]
        public decimal VatPercent { get; set; }

        [Display(Name = "Vat(TK)")]
        [DefaultValue(0)]
        public decimal VatAmount { get; set; }

        [Display(Name = "Net Amount")]
        [DefaultValue(0)]
        [Required]
        public decimal NetAmount { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Payable { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Sale(H) Code")]
        [StringLength(15)]
        public string ReferenceCode { get; set; }
        [ForeignKey("ReferenceCode")]
        public virtual VSSalesHead SalesHead { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public string BranchCode { get; set; }
        [ForeignKey("BranchCode")]
        public virtual Branch Branch { get; set; }

        [StringLength(15)]
        [Display(Name = "Shop Name")]
        public string ShopCode { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }
    }
}
