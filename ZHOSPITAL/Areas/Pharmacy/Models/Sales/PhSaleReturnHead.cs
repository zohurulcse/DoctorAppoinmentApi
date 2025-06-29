using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Sales
{
    [Table("PhSaleReturnHead")]
    public class PhSaleReturnHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [StringLength(15)]
        public string CustomCode { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime SaleReturnDate { get; set; }
      
        [Required]
        public int CustomerID { get; set; }
        [NotMapped]
        [StringLength(30)]
        public string CustomerName { get; set; }

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
        public long SaleID { get; set; }

        [Required]
        public int ShopID { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [Required]
        public int InBy { get; set; }

        [StringLength(50)]
        public string InPC { get; set; }
        public int UpBy { get; set; }

        [StringLength(50)]
        public string UpPC { get; set; }
        public virtual List<PhSaleReturnDetails> PhSaleReturnDetails { get; set; }
    }
}
