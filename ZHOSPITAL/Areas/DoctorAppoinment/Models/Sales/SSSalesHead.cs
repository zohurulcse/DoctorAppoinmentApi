using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Areas.VarietiesStore.Models.HRM;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.VarietiesStore.Models.Sales
{
    [Table("SSSalesHead")]
    public class SSSalesHead
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Sales Man")]
        public string EmployeeCode { get; set; }
        [ForeignKey("EmployeeCode")]
        public virtual VSEmployee Employee { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerCode { get; set; }

        //[ForeignKey("CustomerCode")]
        //public virtual Customer Customer { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [Display(Name = "Tatal Quantity")]
        [DefaultValue(0)]
        public decimal TotalQuantity { get; set; }

        [Display(Name = "Total Amount")]
        [DefaultValue(0)]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Discount(%)")]
        public decimal? TotalDiscountPercent { get; set; }

        [Display(Name = "Discount(TK)")]
        public decimal? TotalDiscount { get; set; }

        [Display(Name = "Grand Total")]
        [DefaultValue(0)]
        public double GrandTotal { get; set; }

        [Display(Name = "Vat(%)")]
        public decimal? VatPercent { get; set; }

        [Display(Name = "Vat(TK)")]
        public decimal? VatAmount { get; set; }

        [Display(Name = "Service Charge(%)")]
        public decimal? ServiceChargePercent { get; set; }

        [Display(Name = "Service Charge(tk)")]
        public decimal? ServiceChargeAmount { get; set; }

        [Display(Name = "Net Amount")]
        [DefaultValue(0)]
        public decimal NetAmount { get; set; }

        public decimal? Adjust { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Payable { get; set; }

        [StringLength(20)]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        [StringLength(30)]
        [Display(Name = "Bank")]
        public string BankCode { get; set; }

        //[ForeignKey("BankCode")]
        //public virtual Bank Bank { get; set; }

        [StringLength(30)]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Cash Amount")]
        [DefaultValue(0)]
        public decimal CashAmount { get; set; }

        [Display(Name = "Card Amount")]
        public decimal? CardAmount { get; set; }

        [Display(Name = "Pay Amount")]
        [DefaultValue(0)]
        public decimal PayAmount { get; set; }

        [Display(Name = "Return Amount")]
        public decimal? ChangeAmount { get; set; }

        public decimal? Split { get; set; }

        [StringLength(8)]
        public string Status { get; set; }

        [StringLength(15)]
        [Display(Name = "Shop Name")]
        public string ShopCode { get; set; }

        [Required]
        [StringLength(15)]
        public string BranchCode { get; set; }
        [ForeignKey("BranchCode")]
        public virtual Branch Branch { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        public bool? IsOnline { get; set; }
    }
}
