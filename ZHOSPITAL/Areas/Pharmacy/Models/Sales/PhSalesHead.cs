using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Sales
{
    [Table("PhSalesHead")]
    public class PhSalesHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [StringLength(15)]
        public string CustomCode { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime Date { get; set; }

        [Required]      
        public int UserID { get; set; }
        public int CustomerID { get; set; }

        [NotMapped]
        [StringLength(20)]
        public string CustomerName { get; set; }

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

        //[Required]
        [DefaultValue(0)]
        public decimal Payable { get; set; }
       
        public Int16 PaymentTypeID { get; set; }

        [StringLength(30)]
        [Display(Name = "Bank")]
        public string BankID { get; set; }

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

        [Required]
        public int ShopID { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        public bool? IsOnline { get; set; }

        [Required]
        public int InBy { get; set; }

        [StringLength(50)]
        public string InPC { get; set; }
        public int UpBy { get; set; }

        [StringLength(50)]
        public string UpPC { get; set; }

        public virtual List<PhSalesDetails> PhSalesDetails { get; set; }
    }
}
