using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Purchase
{
    [Table("PhPurchaseReturnHead")]
    public class PhPurchaseReturnHead
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]
        public string CustomCode { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime Date { get; set; }

        [Required]       
        public int SupplierID { get; set; }

        [NotMapped]
        [StringLength(30)]
        public string SupplierName { get; set; }

        [Required]
        [Display(Name = "Total Quantity")]
        public decimal TotalQuantity { get; set; }

        [Required]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }

        [Required]      
        public long PurchaseID { get; set; }

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

        public virtual List<PhPurchaseReturnDetails> PhPurchaseReturnDetails { get; set; }

    }
}
