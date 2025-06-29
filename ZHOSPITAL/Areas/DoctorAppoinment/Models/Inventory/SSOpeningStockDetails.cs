using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;
using ZAPI.Areas.VarietiesStore.Models.ProductSetup;
using ZAPI.Areas.VarietiesStore.Models.Purchase;

namespace ZAPI.Areas.SupperShop.Models.Inventory
{
    [Table("SSOpeningStockDetails")]
    public class SSOpeningStockDetails
    {
        [Key]
        [StringLength(15)]
        [Required]
        public string Code { get; set; }

        [StringLength(15)]
        [Required]
        public string HeadCode { get; set; }
        [ForeignKey("HeadCode")]
        public VSOpeningStockHead OpeningStockHead { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Product")]
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public virtual VSProduct Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
