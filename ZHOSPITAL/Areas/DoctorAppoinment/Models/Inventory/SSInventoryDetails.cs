using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.Inventory;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSInventoryDetails")]
    public class SSInventoryDetails
    {
        [Required, Key]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        public string HeadCode { get; set; }
        [ForeignKey("HeadCode")]
        public virtual VSInventoryHead InventoryHead { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Stock Quantity")]
        public decimal StockQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Inventory Quantity")]
        public decimal InventoryQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        [Display(Name = "Adjust Quantity")]
        public decimal AdjustQuantity { get; set; }
    }
}
