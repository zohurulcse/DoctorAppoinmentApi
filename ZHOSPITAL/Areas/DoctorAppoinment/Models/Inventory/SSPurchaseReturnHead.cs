using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Areas.VarietiesStore.Models.CRM;
using ZAPI.Areas.VarietiesStore.Models.Purchase;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.VarietiesStore.Models.Inventory
{
    [Table("SSPurchaseReturnHead")]
    public class SSPurchaseReturnHead
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public string SupplierCode { get; set; }
        [ForeignKey("SupplierCode")]
        public virtual VSSupplier Supplier { get; set; }

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
        [Display(Name = "Purchase(H) Code")]
        public string ReferenceCode { get; set; }
        [ForeignKey("ReferenceCode")]
        public virtual VSPurchaseHead PurchaseHead { get; set; }

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
