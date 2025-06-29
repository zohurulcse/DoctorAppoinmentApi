using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZAPI.Areas.VarietiesStore.Models.CRM;
using ZAPI.Models.Setup;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSOpeningStockHead")]
    public class SSOpeningStockHead
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Date { get; set; }

        [StringLength(15)]
        [Required]
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
        public virtual Branch Branch { get; set; }
    }
}
