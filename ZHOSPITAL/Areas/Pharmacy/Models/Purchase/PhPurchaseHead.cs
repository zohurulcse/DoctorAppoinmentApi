using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZHOSPITAL.Models.Setup;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Purchase
{
    [Table("PhPurchaseHead")]
    public class PhPurchaseHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [StringLength(15)]      
        public string CustomCode { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime PurchaseDate { get; set; }

        [StringLength(30)]
        [Display(Name = "Innvoice Number")]
        public string InnvoiceNumber { get; set; }
              
        public int SupplierID { get; set; }

        [StringLength(30)]
        [NotMapped]
        public string SupplierName { get; set; }

        [Display(Name = "Total Quantity")]
        public decimal? TotalQuantity { get; set; }

        [Display(Name = "Net Amount")]
        public decimal? NetAmount { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(10)]
        [Required]
        public string Status { get; set; }
       
        public int BranchID { get; set; }
      
        public int UserID { get; set; }
     
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

        public virtual List<PhPurchaseDetails> PhPurchaseDetails { get; set; }
    }
}
