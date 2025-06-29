using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSInventoryHead")]
    public class SSInventoryHead
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MMM-yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MMM-yyyy}")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Stock Quantity")]
        public decimal TotalStockQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Inventory Quantity")]
        public decimal TotalInventoryQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Adjust Quantity")]
        public decimal TotalAdjustQuantity { get; set; }

        [Required]
        [StringLength(8)]
        public string Status { get; set; }

        [StringLength(20)]
        public string ApproveStatus { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public string BranchCode { get; set; }
        [ForeignKey("BranchCode")]
        public virtual Branch Branch { get; set; }
    }
}
