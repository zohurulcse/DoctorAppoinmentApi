using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;
using ZAPI.Areas.VarietiesStore.Models.Purchase;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSPurchaseOrderDetails")]
    public class SSPurchaseOrderDetails
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(15)]
        [Required]
        public string HeadCode { get; set; }
        [ForeignKey("HeadCode")]
        public virtual VSPurchaseOrderHead PurchaseOrderHead { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Product")]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }

        [Required]
        [Range(1, 99999)]
        public decimal Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        //[Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        [StringLength(15)]
        [Display(Name = "Size")]
        public string SizeCode { get; set; }
        [ForeignKey("SizeCode")]
        public virtual VSSize Size { get; set; }

        [StringLength(15)]
        [Display(Name = "Color")]
        public string Color { get; set; }
        [ForeignKey("Color")]
        public virtual VSColor Colors { get; set; }

        //[StringLength(20)]
        //public string Color { get; set; }
    }
}
