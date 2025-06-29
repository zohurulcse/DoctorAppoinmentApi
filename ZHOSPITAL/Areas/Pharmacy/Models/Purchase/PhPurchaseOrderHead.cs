using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZHOSPITAL.Areas.Pharmacy.Models.Purchase
{
    [Table("PhPurchaseOrderHead")]
    public class PhPurchaseOrderHead
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(15)]      
        public string CustomCode { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Date { get; set; }
       
        [Required]
        public int SupplierID { get; set; }

        [Display(Name = "Total Quantity")]
        public decimal? TotalQuantity { get; set; }

        [Display(Name = "Total Amount")]
        public decimal? TotalAmount { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        [StringLength(10)]
        [Required]
        public string Status { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [Required]
        public int ShopID { get; set; }

        public virtual List<PhPurchaseOrderDetails> PhPurchaseOrderDetails { get; set; }
    }
}
