using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Areas.VarietiesStore.Models.CRM;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSPurchaseHead")]
    public class SSPurchaseHead
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Date { get; set; }

        [StringLength(30)]
        [Display(Name = "Innvoice Number")]
        public string InnvoiceNumber { get; set; }

        [StringLength(15)]
        [Display(Name = "Supplier")]
        public string SupplierCode { get; set; }
        [ForeignKey("SupplierCode")]
        public virtual VSSupplier Supplier { get; set; }

        [Display(Name = "Total Quantity")]
        public decimal? TotalQuantity { get; set; }

        [Display(Name = "Net Amount")]
        public decimal? NetAmount { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(10)]
        [Required]
        public string Status { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Branch")]
        public string BranchCode { get; set; }
        [ForeignKey("BranchCode")]
        public Branch Branch { get; set; }

        [StringLength(15)]
        [Display(Name = "User Name")]
        public string UserCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Shop Name")]
        public string ShopCode { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }
    }
}
