using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAPI.Areas.VarietiesStore.Models.CRM;

namespace DataAccessLayer.Model
{
    [Table("SSProductOrder")]
    public class SSProductOrder
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime OrderDate { get; set; }
        
        [Display(Name = "Total Quantity")]
        public Nullable<decimal> TotalQuantity { get; set; }

        [Display(Name = "Total Amount")]
        public Nullable<decimal> TotalAmount { get; set; }

        [Display(Name = "Discount(%)")]
        public decimal? TotalDiscountPercent { get; set; }

        [Display(Name = "Discount(TK)")]
        public decimal? TotalDiscount { get; set; }

        [Display(Name = "Advance Amount")]
        [DefaultValue(0)]
        public decimal AdvanceAmount { get; set; }

        [Display(Name = "Grand Total")]
        [DefaultValue(0)]
        public double GrandTotal { get; set; }

        [Display(Name = "Vat(%)")]
        public decimal? VatPercent { get; set; }

        [Display(Name = "Vat(TK)")]
        public decimal? VatAmount { get; set; }
        
        [Display(Name = "Delivery Charge(tk)")]
        public decimal? DeliveryChargeAmount { get; set; }

        [Display(Name = "Net Amount")]
        [DefaultValue(0)]
        public decimal NetAmount { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Payable { get; set; }

        [StringLength(20)]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        [StringLength(30)]
        [Display(Name = "Bank")]
        public string BankCode { get; set; }       

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

        [StringLength(20)]
        [Required]
        public string OrderStatus { get; set; }       
        public string Remarks { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Customer")]
        public string CustomerCode { get; set; }
        [ForeignKey("CustomerCode")]
        public virtual VSCustomer Customer { get; set; }
    }
}
